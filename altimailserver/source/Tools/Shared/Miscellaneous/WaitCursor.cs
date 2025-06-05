// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AltimailServer.Shared
{
    public class WaitCursor : IDisposable
    {
        public WaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = Cursors.Default;

        }
    }
}
