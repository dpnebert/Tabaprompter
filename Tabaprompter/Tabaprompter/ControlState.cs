using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    enum ControlState
    {
        initial = 0,
        unsaved_library_loaded = 1,
        saved_library_loaded = 2,
        unsaved_library_tab_loaded = 3,
        saved_library_tab_loaded = 4,
    }
}
