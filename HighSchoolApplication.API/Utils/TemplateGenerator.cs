using DotLiquid;
using DotLiquid.NamingConventions;
using HighSchoolApplication.API.Drops;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Utils
{
    public class TemplateGenerator
    {
        public static string GetStudentCertificationHtml(string DocumentDescription,StudentCertificationDrop model)
        {
            if (DocumentDescription.ToLower() == "vertetim")
            {
                StudentCertificationDrop data = model;

                string liquidTemplateFilePath = "./Templates/StudentCertification.html";
                Template template = GetTemplate(liquidTemplateFilePath);

                Hash hash = Hash.FromAnonymousObject(new { Model = data });

                string renderedOutput = template.Render(hash);

                return renderedOutput;
            }
            else return null;
        }

        private static Template GetTemplate(string templateFilePath)
        {
            Liquid.UseRubyDateFormat = false;
            // Setting this means that:
            // - Properties are accessed using CamelCase e.g. Model.PolicyNumber
            // - Filters are accessed using CamelCase e.g. Date
            Template.NamingConvention = new CSharpNamingConvention();

            string liquidTemplateContent = File.ReadAllText(templateFilePath);

            Template template = Template.Parse(liquidTemplateContent);
            template.MakeThreadSafe();

            return template;
        }
    }
}
