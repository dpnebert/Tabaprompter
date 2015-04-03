using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    enum ControlState
    {
        initial = 0,
        library_loaded = 1,
        library_tab_loaded = 2,
        library_tab_loaded_play_mode = 3,
        library_tab_loaded_mark_mode = 4
    }
}
