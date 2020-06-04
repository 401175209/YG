using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using YG.WorkArea.ViewModels.WorkVMs;
using YG.TemplateArea.ViewModels.TemplateVMs;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.IO;
using System.ComponentModel;

namespace YG.Controllers
{
   
        /// <summary>
        /// Sprie.Doc
        /// Designed by XIAO
        /// 2017-05-09
        /// </summary>
        public class WordHandler
        {
            public static bool ExportWordByFields<T>(T mod, string TempleteFilePath, string ExpFilePath)
            {
                if (mod == null)
                {
                    throw new Exception("模型为空！");
                }

                System.Reflection.PropertyInfo[] properties = mod.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (properties.Length <= 0)
                {
                    throw new Exception("模型属性为空！");
                }

                if (!File.Exists(TempleteFilePath))
                {
                    throw new Exception("指定路径的模板文件不存在！");
                }

                try
                {
                    Document doc = new Document();
                    doc.LoadFromFile(TempleteFilePath);

                    #region 替换文字
                    //doc.Replace("海关", "海关口岸", true, true);
                    //doc.Replace("报验", "报检", true, true);
                    #endregion

                    //清除表单域阴影
                    doc.Properties.FormFieldShading = false;

                    //遍历Word模板中的文本域（field.name为文本域名称）
                    foreach (FormField field in doc.Sections[0].Body.FormFields)
                    {
                        foreach (System.Reflection.PropertyInfo prop in properties)
                        {
                            string name = prop.Name; //属性名称
                            object value = prop.GetValue(mod, null);  //属性值
                            string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute))).Description;// 属性描述值

                            //注意：文本域名称 == 模型中属性的 Description 值 ！！！！！！
                            //也可以： 文本域名称 == 模型中属性的 Name 值 ！！！！！！
                            if (field.Name == des)
                            {
                                if (field.DocumentObjectType == DocumentObjectType.TextFormField)   //文本域
                                {
                                    if (prop.PropertyType.Name == "Boolean")
                                    {
                                        field.Text = "√";   //插入勾选符号
                                        break;
                                    }
                                    else
                                    {
                                        field.Text = value.ToString();   //向Word模板中插入值
                                        break;
                                    }
                                }
                                else if (field.DocumentObjectType == DocumentObjectType.CheckBox)   //复选框
                                {
                                    (field as CheckBoxFormField).Checked = (value as bool?).HasValue ? (value as bool?).Value : false;
                                }
                            }
                        }
                    }

                    doc.SaveToFile(ExpFilePath, FileFormat.Docx);
                    doc.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;

                    return false;
                }
            }
        }
    }