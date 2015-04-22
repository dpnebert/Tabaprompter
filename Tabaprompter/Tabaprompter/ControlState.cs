using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    enum ControlState
    {
        initial = 0,
        library_loaded,
        library_tab_loaded,
        library_tab_loaded_play_mode,
        library_tab_loaded_stop_mode,
        library_tab_loaded_mark_mode
    }
}
