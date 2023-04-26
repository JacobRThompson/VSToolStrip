using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedControls
{
    public static class Globals
    {
        internal const bool SHOW_IN_TOOLBOX = true;

        public const string TYPED_CONTROL_ROOT_CATEGORY = "Strongly-Typed Control";

        public static Action<Control, String>? SetErrorValidationFailed { get; set; }
        public static Action<Control, String>? SetErrorRequiredLocally { get; set; }
        public static Action<Control, String>? SetErrorRequiredGlobally { get; set; }

        public static string RequiredLocallyMsg { get; set; } = "(DEBUG) This is required locally";
        public static string RequiredGloballyMsg { get; set; } = string.Empty;
    }
}
