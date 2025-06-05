// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System;
using System.Collections.Generic;
using System.Text;

namespace AltimailServer.Shared
{
    public interface IPropertyEditor
    {
        bool Dirty
        {
            get;
        }

        void SetClean();
    }
}
