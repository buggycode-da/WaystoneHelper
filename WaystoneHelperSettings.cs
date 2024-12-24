using System.Windows.Forms;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;

namespace WaysstoneHelper;

public class WaystoneHelperSettings : ISettings
{
    public ToggleNode Enable { get; set; } = new(false);

}

[Submenu]
public class FlaskSettings(Keys hotkey)
{
   
}

