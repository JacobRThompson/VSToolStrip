using Honeycomb.UI.Properties;
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
    public class SvgResourceEditor : UITypeEditor
    {
        // Specifies that the property will use a modal dialog window for editing
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        // Displays the Open File dialog and returns the selected resource key
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var openFileDialog = new OpenFileDialog
            {
                // Filter the files to only show SVG files
                Filter = "All Files|*.*",
                // Set the title of the Open File dialog
                Title = "Select an SVG file from resources"
            };

            // Show the Open File dialog and check if the user clicked OK
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Get the selected file name and create a resource key from it
                var resourceName = openFileDialog.FileName;
                var resourceNameParts = resourceName.Split(new[] { '\\', '/' });
                var fileName = resourceNameParts[resourceNameParts.Length - 1];
                var resourceKey = fileName.Replace(".", "_");

                // Try to get the value of the resource with the generated key
                var resourceManager = new System.Resources.ResourceManager(typeof(Resources));
                var resourceValue = resourceManager.GetObject(resourceKey);

                // If the resource value exists, return the generated key
                if (resourceValue != null)
                {
                    return resourceKey;
                }
            }

            // If the user cancelled or if there was an error, fall back to the default behavior
            return base.EditValue(context, provider, value);
        }
    }
}
