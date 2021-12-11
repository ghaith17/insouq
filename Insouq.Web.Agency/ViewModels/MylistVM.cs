﻿using insouq.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.Models
{
    public class MylistVM
    {
        public List<AdCountDTO> MyAdsCount { get; set; }
        public List<AdCountDTO> MyFavoriteCount { get; set; }
        public List<AdCountDTO> MySavedSearchCount { get; set; }
    }
}
