using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public static class Globals
    {
        internal const bool SHOW_BASE_COMPONENTS_IN_TOOLBOX = true;

        public const string TYPED_CONTROL_ROOT_CATEGORY = "Strongly-Typed Control";

        public static Action<Control, String> SetErrorValidationFailed { get; set; } = delegate { };
        public static Action<Control, String> SetErrorRequiredLocally { get; set; } = delegate { };
        public static Action<Control, String> SetErrorRequiredGlobally { get; set; } = delegate { };

        public static string RequiredLocallyMsg { get; set; } = "(DEBUG) This is required locally";
        public static string RequiredGloballyMsg { get; set; } = string.Empty;
    }
}
