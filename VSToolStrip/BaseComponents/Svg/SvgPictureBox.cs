using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Honeycomb.UI.BaseComponents.Svg
{
    public class SvgPictureBox : PictureBox
    {
        private string _svgFile = string.Empty;

        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public string SvgFile
        {
            get { return _svgFile; }
            set
            {
                _svgFile = value;
                SetSvgFromResource(_svgFile);
            }
        }

        private void SetSvgFromResource(string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                return;
            }

            using (var stream = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var svgXml = reader.ReadToEnd();
                        var svgDocument = SvgDocument.FromSvg<SvgDocument>(svgXml);
                        Image = svgDocument.Draw();
                    }
                }
            }
        }


    }
}
