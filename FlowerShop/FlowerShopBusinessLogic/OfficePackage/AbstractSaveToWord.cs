using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopBusinessLogic.OfficePackage.HelperEnums;
using FlowerShopBusinessLogic.OfficePackage.HelperModels;

namespace FlowerShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            if (info.ReportType == WordReportType.ReportFlowers)
            {
                CreateWord(info);
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties {
                    Bold = true,
                    Size = "24",
                })
                },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Center
                    }
                });
                foreach (var flower in info.Flowers)
                {
                    CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> {
                        (flower.FlowerName + ": ", new WordTextProperties {
                        Size = "24",
                        Bold = true
                        }),
                        (Convert.ToInt32(flower.Price).ToString(), new WordTextProperties {
                        Size = "24"
                        })
                    },
                        TextProperties = new WordTextProperties
                        {
                            Size = "24",
                            JustificationType = WordJustificationType.Both
                        }
                    });
                }
                SaveWord(info);
            }
            if (info.ReportType == WordReportType.ReportStorhouses)
            {
                CreateWord(info);
                CreateTable(new WordTable
                {
                    Header = info.Title,
                    Rows = info.Storehouses,
                    TableProperties = new WordTableProperties 
                    {
                        TextSize = "45",
                        BorderSize = "7",
                        BorderType = WordBorderType.Wave
                    }
                });
                SaveWord(info);
            }
        }
        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);
        
        // Создание таблицы в Word
        protected abstract void CreateTable(WordTable wordTable);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);

    }
}
