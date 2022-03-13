﻿using System;
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
                    Texts = new List<(string, WordTextProperties)> {(flower.FlowerName, new WordTextProperties {
                        Size = "24",
                        Bold = true,
                    }) 
                    },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }

                });
                string price = ": " + Convert.ToInt32(flower.Price).ToString();
                CreateParagraph(new WordParagraph
                {                    
                    Texts = new List<(string, WordTextProperties)> {(price, new WordTextProperties {
                        Size = "24",
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
        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);

    }
}
