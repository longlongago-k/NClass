﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NClass.Core
{
    /// <summary>
    /// This is helper class providing default implementation methods for INestableChild interface
    /// </summary>
    internal class NestableChildHelper
    {
        INestableChild nestableChild = null;
        INestable nestingParent = null;

        internal event NestingChildEventHandler  NestingParentChanged;

        internal NestableChildHelper(INestableChild nestableChild)
        {
            this.nestableChild = nestableChild ?? throw new ArgumentException(nameof(nestableChild));
        }

        internal INestable NestingParent
        {
            get
            {
                return nestingParent;
            }
            set
            {
                if (nestingParent != value)
                {
                    nestingParent = value;
                    OnNestingParentChanged(new NestingChildEventArgs(nestingParent));
                }
            }
        }

        private void OnNestingParentChanged(NestingChildEventArgs e)
        {
            NestingParentChanged?.Invoke(this, e);
        }
    }
}
