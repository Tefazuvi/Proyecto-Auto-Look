﻿using System;
namespace AutoLook.Model
{
    public class MasterPageItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}
