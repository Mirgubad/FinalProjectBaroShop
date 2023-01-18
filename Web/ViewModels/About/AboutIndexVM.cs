using Core.Entities;

namespace Web.ViewModels.About
{
    public class AboutIndexVM
    {
        public List<BusinessInfo> BusinessInfos { get; set; }
        public List<Fact> Facts { get; set; }

        public WhatWedo WhatWedo { get; set; }
    }
}
