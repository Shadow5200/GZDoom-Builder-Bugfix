﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeImp.DoomBuilder.PropertiesDock {
    interface IMapElementInfo {
        void ApplyChanges();
        void AddCustomProperty(string name, Type type);
        void RemoveCustomProperty(string name);
    }
}