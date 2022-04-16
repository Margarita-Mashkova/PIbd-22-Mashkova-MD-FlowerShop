using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopBusinessLogic.OfficePackage.HelperModels;
using FlowerShopBusinessLogic.OfficePackage.HelperEnums;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace FlowerShopBusinessLogic.OfficePackage.Implements
{
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument _wordDocument;
        private Body _docBody;
        // Получение типа выравнивания
        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            return type switch
            {
                WordJustificationType.Both => JustificationValues.Both,
                WordJustificationType.Center => JustificationValues.Center,
                _ => JustificationValues.Left,
            };
        }
        // Получение типа границы
        private static BorderValues GetBorderValues(WordBorderType type)
        {
            return type switch
            {
                WordBorderType.Single => BorderValues.Single,
                WordBorderType.Dashed => BorderValues.Dashed,
                WordBorderType.Dotted => BorderValues.Dotted,
                WordBorderType.Wave => BorderValues.Wave,
                _ => BorderValues.Hearts
            };
        }
        // Настройки страницы
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }
        // Задание форматирования для абзаца
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                var properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = GetJustificationValues(paragraphProperties.JustificationType)
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                var paragraphMarkRunProperties = new ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize
                    {
                        Val = paragraphProperties.Size
                    });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }
        private static TableProperties CreateTableProperties(WordTableProperties wordTableProperties)
        {
            if (wordTableProperties != null)
            {
                var properties = new TableProperties();
                properties.AppendChild(new FontSize()
                {
                    Val = wordTableProperties.TextSize
                });
                properties.AppendChild(new TableBorders(
                new TopBorder
                {
                    Val = GetBorderValues(wordTableProperties.BorderType),
                    Size = Convert.ToUInt32(wordTableProperties.BorderSize)
                },
                new BottomBorder
                {
                    Val = GetBorderValues(wordTableProperties.BorderType),
                    Size = Convert.ToUInt32(wordTableProperties.BorderSize)
                },
                new LeftBorder
                {
                    Val = GetBorderValues(wordTableProperties.BorderType),
                    Size = Convert.ToUInt32(wordTableProperties.BorderSize)
                },
                new RightBorder
                {
                    Val = GetBorderValues(wordTableProperties.BorderType),
                    Size = Convert.ToUInt32(wordTableProperties.BorderSize)
                },
                new InsideHorizontalBorder
                {
                    Val = GetBorderValues(wordTableProperties.BorderType),
                    Size = Convert.ToUInt32(wordTableProperties.BorderSize)
                },
                new InsideVerticalBorder
                {
                    Val = GetBorderValues(wordTableProperties.BorderType),
                    Size = Convert.ToUInt32(wordTableProperties.BorderSize)
                }));
                return properties;
            }
            return null;
        }
        protected override void CreateWord(WordInfo info)
        {
            _wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document);
            MainDocumentPart mainPart = _wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            _docBody = mainPart.Document.AppendChild(new Body());
        }
        protected override void CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                var docParagraph = new Paragraph();

                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    var docRun = new Run();
                    var properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space = SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                _docBody.AppendChild(docParagraph);
            }
        }        
        protected override void SaveWord(WordInfo info)
        {
            _docBody.AppendChild(CreateSectionProperties());
            _wordDocument.MainDocumentPart.Document.Save();
            _wordDocument.Close();
        }
        protected override void CreateTable(WordTable wordTable)
        {
            if (wordTable != null)
            {
                Table table = new Table();
                table.AppendChild(CreateTableProperties(wordTable.TableProperties));
                TableRow rowHeader = new TableRow();
                TableCell cellHeader = new TableCell();
                cellHeader.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "7200" },
                    new HorizontalMerge() { Val = MergedCellValues.Restart }));
                WordTextProperties textProperties = new WordTextProperties()
                {
                    JustificationType = WordJustificationType.Center
                };
                cellHeader.Append(new Paragraph(new Run(new Text(wordTable.Header))));
                cellHeader.GetFirstChild<Paragraph>().ParagraphProperties = CreateParagraphProperties(textProperties);
                TableCell tmpCell1 = new TableCell();
                tmpCell1.Append(new TableCellProperties(new HorizontalMerge() { Val = MergedCellValues.Continue }));
                tmpCell1.Append(new Paragraph(new Run(new Text(""))));
                TableCell tmpCell2 = new TableCell();
                tmpCell2.Append(new TableCellProperties(new HorizontalMerge() { Val = MergedCellValues.Continue }));
                tmpCell2.Append(new Paragraph(new Run(new Text(""))));
                rowHeader.Append(cellHeader);
                rowHeader.Append(tmpCell1);
                rowHeader.Append(tmpCell2);
                table.Append(rowHeader);

                foreach (var row in wordTable.Rows)
                {
                    TableCell cellStorehouseName = new TableCell();
                    TableCell cellResponsibilityFIO = new TableCell();
                    TableCell cellDateCreate = new TableCell();

                    TableRow rowData = new TableRow();

                    cellStorehouseName.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cellStorehouseName.Append(new Paragraph(new Run(new Text(row.StorehouseName))));
                    cellResponsibilityFIO.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cellResponsibilityFIO.Append(new Paragraph(new Run(new Text(row.ResponsibleFullName))));
                    cellDateCreate.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cellDateCreate.Append(new Paragraph(new Run(new Text(row.DateCreate.ToString()))));
                    rowData.Append(cellStorehouseName);
                    rowData.Append(cellResponsibilityFIO);
                    rowData.Append(cellDateCreate);

                    table.Append(rowData);
                }
                _docBody.AppendChild(table);
            }
        }
    }
}
