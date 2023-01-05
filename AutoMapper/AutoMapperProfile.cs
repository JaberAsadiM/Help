using System;
using Amard.Shahrsazi.DataAccess.DbContext;
using Amard.Shahrsazi.Web.Framework.Enums;
using Amard.Shahrsazi.Web.UI.Areas.Asnaf.Models;
using Amard.Shahrsazi.Web.UI.Areas.Made100.Models.AccountTypeMade100;
using Amard.Shahrsazi.Web.UI.Areas.Made100.Models.BuildingTypeMade100;
using Amard.Shahrsazi.Web.UI.Areas.Made100.Models.DensityMade100;
using Amard.Shahrsazi.Web.UI.Areas.Made100.Models.RegionalPricesMade100;
using Amard.Shahrsazi.Web.UI.Areas.Made100.Models.TypeStructuresMaterialsMade100;
using Amard.Shahrsazi.Web.UI.Areas.Marahel.Models;
using Amard.Shahrsazi.Web.UI.Areas.Marahel.Models.FoulDefinition;
using Amard.Shahrsazi.Web.UI.Areas.Marahel.Models.ViewModels;
using Amard.Shahrsazi.Web.UI.Areas.Parvandeh.Models;
using AmardWebShahrsazi.Areas.Definitions.Models;
using AmardWebShahrsazi.Models.Enum;
using AutoMapper;
using DNTPersianUtils.Core;
using Amard.Shahrsazi.DataAccess.Models.ViewModels.FoulDefinition;
using Amard.Shahrsazi.DataAccess.Models;
using AmardWebShahrsazi.Content;
using Amard.Shahrsazi.Web.UI.Areas.Made100.Models;
using System.Linq;
using System.Web.WebPages.Html;
using System.ComponentModel.DataAnnotations;
using Amard.Shahrsazi.Core.Utilities;

namespace Amard.Shahrsazi.Web.UI.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region General

            CreateMap<DateTime, string>().ConvertUsing(value => value.ToShortPersianDateString(true));
            CreateMap<string, DateTime>().ConvertUsing(value => value.ToGregorianDateTime(false, 1300) ?? DateTime.Now);
            CreateMap<DateTime?, string>().ConvertUsing(value => value.ToShortPersianDateString(true));
            CreateMap<string, DateTime?>().ConvertUsing(value => value.ToGregorianDateTime(false, 1300));
            CreateMap<int?, DateTime?>().ConvertUsing(value => 
                                        MyFunctions.ConvertIntPersinDateToMiladiDate(value.GetValueOrDefault()));
            CreateMap<DateTime?, int?>().ConvertUsing(value => value == null ? 0 :
                                        MyFunctions.ConvertMiladiDateToIntPersian(value.GetValueOrDefault()));

            #endregion

            #region PosInfo

            CreateMap<PosType, byte>().ConvertUsing(value => (byte)value);
            CreateMap<byte, PosType>().ConvertUsing(value => (PosType)value);

            CreateMap<CompanyPosType, byte>().ConvertUsing(value => (byte)value);
            CreateMap<byte, CompanyPosType>().ConvertUsing(value => (CompanyPosType)value);

            CreateMap<PosInfo, PosInfoViewModel>().ReverseMap();

            #endregion

            #region AccountType


            CreateMap<AccountType, AccountTypeViewModel>().ReverseMap();
            CreateMap<AccountTypeDetail, AccountTypeDetailViewModel>().ReverseMap();

            #endregion

            #region BuildingType

            CreateMap<BuildingType, BuildingTypeViewModel>().ReverseMap();
            CreateMap<BuildingTypeDetail, BuildingTypeDetailViewModel>().ReverseMap();

            #endregion

            #region Density

            CreateMap<Density, DensityViewModel>().ReverseMap();
            CreateMap<DensityDetail, DensityDetailViewModel>().ReverseMap();

            #endregion

            #region RegionalPrices

            CreateMap<RegionalPrices, RegionalPricesViewModel>().ReverseMap();
            CreateMap<RegionalPricesDetail, RegionalPricesDetailViewModel>().ReverseMap();

            #endregion

            #region TypeStructuresMaterials

            CreateMap<TypeStructuresMaterials, TypeStructuresMaterialsViewModel>().ReverseMap();
            CreateMap<TypeStructuresMaterialsDetail, TypeStructuresMaterialsDetailViewModel>().ReverseMap();

            #endregion

            #region IncomeRating

            CreateMap<IncomeRating, IncomeRatingViewModel>().ReverseMap();

            #endregion

            #region PositionRank

            CreateMap<PositionRank, PositionRankViewModel>().ReverseMap();

            #endregion

            #region ProfessionalRank

            CreateMap<ProfessionalRank, ProfessionalRankViewModel>().ReverseMap();

            #endregion

            #region IncomeRating

            CreateMap<ProfessionalRank, ProfessionalRankViewModel>().ReverseMap();


            #endregion

            #region Dv_ListShoghl

            CreateMap<Dv_ListShoghl, ListShoghlViewModel>().ReverseMap();

            #endregion

            #region MasahatKhalaf

            CreateMap<ZavabetType, byte?>().ConvertUsing(value => value == ZavabetType.None ? null : (byte?)value);
            CreateMap<byte?, ZavabetType>().ConvertUsing(value => value == null ? ZavabetType.None : (ZavabetType)value);

            CreateMap<EnumFoulDefinitionType, byte?>().ConvertUsing(value => value == null ? 0 : (byte?)value);
            CreateMap<byte?, EnumFoulDefinitionType>().ConvertUsing(value => value == null ? EnumFoulDefinitionType.None : (EnumFoulDefinitionType)value);
            CreateMap<EnumFoulDefinitionType, EnumFoulDefinitionType>().ConvertUsing(value => value == null ? EnumFoulDefinitionType.None : (EnumFoulDefinitionType)value);

            CreateMap<masahat_khalaf, MasahatKhalafViewModel>().AfterMap((src, dest) => {
                dest.EnumFoulDefinitionType_Name = MyFunctions.GetDisplayEnumName(dest.EnumFoulDefinitionType);
            });

            CreateMap<MasahatKhalafViewModel, masahat_khalaf>().AfterMap((src, dest) =>
            {
                if (src?.c_Tabaghe != null && src?.c_Tabaghe != 0)
                    dest.Tabaghe = AmardWebShahrsazi.Business.SabethaService.GetDataBykodfarei(3, Convert.ToInt32(src.c_Tabaghe)).sharh;

                if (src?.Code_Khalaf != null && src?.Code_Khalaf != 0)
                    dest.Onvan_Khalaf = AmardWebShahrsazi.Business.ParametricService.GetDataBykodfarei(140, Convert.ToInt32(src.Code_Khalaf)).sharh;

                if (src?.Code_Karbari_Asli_Mojaz != null && src?.Code_Karbari_Asli_Mojaz != 0)
                    dest.Onvan_Karbari_Asli_Mojaz = AmardWebShahrsazi.Business.SabethaService.GetDataBykodfarei(1, Convert.ToInt32(src.Code_Karbari_Asli_Mojaz)).sharh;

                if (src?.Code_Karbari_Asli_Mojod != null && src?.Code_Karbari_Asli_Mojod != 0)
                    dest.Onvan_Karbari_Asli_Mojod = AmardWebShahrsazi.Business.SabethaService.GetDataBykodfarei(1, Convert.ToInt32(src.Code_Karbari_Asli_Mojod)).sharh;

                if (src?.Code_Karbari_Farei_Mojaz != null && src?.Code_Karbari_Farei_Mojaz != 0)
                    dest.Onvan_Karbari_Farei_Mojaz = AmardWebShahrsazi.Business.SabethaService.GetDataBykodfarei(2, Convert.ToInt32(src.Code_Karbari_Farei_Mojaz)).sharh;

                if (src?.Code_Karbari_Farei_Mojod != null && src?.Code_Karbari_Farei_Mojod != 0)
                    dest.Onvan_Karbari_Farei_Mojod = AmardWebShahrsazi.Business.SabethaService.GetDataBykodfarei(2, Convert.ToInt32(src.Code_Karbari_Farei_Mojod)).sharh;

                if (src.AccountTypeId == 0)
                    dest.AccountTypeId = null;

                if (src.BuildingTypeId == 0)
                    dest.BuildingTypeId = null;

                if (src.DensityId == 0)
                    dest.DensityId = null;

                if (src.RegionalPricesId == 0)
                    dest.RegionalPricesId = null;

                if (src.TypeStructuresMaterialsId == 0)
                    dest.TypeStructuresMaterialsId = null;
            });

            #endregion

            #region Dv_ListShoghl

            CreateMap<Dv_ListShoghl, ListShoghlViewModel>().ReverseMap();

            #endregion

            #region Dv_karbari

            CreateMap<Dv_karbari, Dv_karbariViewModel>().ReverseMap();
            CreateMap<Dv_karbari, DvKarbariModel>().ReverseMap();
            CreateMap<Dv_karbari, Dv_KarbariModel>().ReverseMap();
            CreateMap<Dv_KarbariModel, Dv_karbari>().AfterMap((src, dest) =>
            {
                if (src.AccountTypeId == 0)
                    dest.AccountTypeId = null;

                if (src.BuildingTypeId == 0)
                    dest.BuildingTypeId = null;

                if (src.DensityId == 0)
                    dest.DensityId = null;

                if (src.TypeStructuresMaterialsId == 0)
                    dest.TypeStructuresMaterialsId = null;

            });
            CreateMap<Dv_karbari, Dv_karbari>().AfterMap((src, dest) =>
            {
                if (src.AccountTypeId == 0)
                    dest.AccountTypeId = null;

                if (src.BuildingTypeId == 0)
                    dest.BuildingTypeId = null;

                if (src.DensityId == 0)
                    dest.DensityId = null;

                if (src.TypeStructuresMaterialsId == 0)
                    dest.TypeStructuresMaterialsId = null;

            });

            CreateMap<DvKarbariModel, masahat_khalaf>().AfterMap((src, dest) =>
            {
                dest.sh_darkhast = src.shod;
                dest.EnumFoulDefinitionType = src.foulDefinitionCode;
                dest.parvaneh = src.areaAllowed;
                dest.Ehdas = src.areaAvailable;
                dest.takhalof = src.areaFoul;
                dest.Code_Karbari_Asli_Mojod = src.c_karbari;
                dest.Onvan_Karbari_Asli_Mojod = src.karbari;
                dest.Code_Karbari_Asli_Mojaz = src.c_karbari_mojaz;
                dest.Onvan_Karbari_Asli_Mojaz = src.karbari_mojaz;
                dest.Code_Karbari_Farei_Mojod = src.c_noeestefadeh;
                dest.Onvan_Karbari_Farei_Mojod = src.noeestefadeh;
                dest.Code_Karbari_Farei_Mojaz = src.c_noeestefadehMojaz;
                dest.Onvan_Karbari_Farei_Mojaz = src.noeestefadehMojaz;
                dest.TedadVahed = src.tedadvahed;
                dest.c_Tabaghe = src.c_tabagheh;
                dest.Tabaghe = src.tabagheh;
                dest.Tarikh = src.tarikhehdas;
                dest.c_noesakhtemanMojod = src.c_noesakhteman;
                dest.noesakhtemanMojod = src.noesakhteman;
                dest.Radif = decimal.ToInt32(src.d_radif);
                dest.BuildingTypeId = src.BuildingTypeId <= 0 ? (int?)null : src.BuildingTypeId;
                dest.AccountTypeId = src.AccountTypeId <= 0 ? (int?)null : src.AccountTypeId;
                dest.TypeStructuresMaterialsId = src.TypeStructuresMaterialsId <= 0 ? (int?)null : src.TypeStructuresMaterialsId;
                dest.DensityId = src.DensityId <= 0 ? (int?)null : src.DensityId;
                dest.Code_Khalaf = 0;
            });

            #endregion

            #region Dv_pishamadegi

            CreateMap<Dv_pishamadegi, Dv_pishamadegiViewModel>().ReverseMap();
            CreateMap<Dv_pishamadegi, DvPishamadegiModel>().ReverseMap();
            CreateMap<Dv_pishamadegi, Dv_pishamadegi>().AfterMap((src, dest) =>
            {
                if (src.AccountTypeId == 0)
                    dest.AccountTypeId = null;

                if (src.BuildingTypeId == 0)
                    dest.BuildingTypeId = null;

                if (src.DensityId == 0)
                    dest.DensityId = null;

                if (src.TypeStructuresMaterialsId == 0)
                    dest.TypeStructuresMaterialsId = null;

            });

            #endregion

            #region Dv_aghabneshini

            CreateMap<Dv_aghabneshini, Dv_aghabneshiniModel>().ReverseMap();

            CreateMap<Dv_aghabneshiniModel, Dv_aghabneshini>().AfterMap((src, dest) =>
            {
                if (src.AccountTypeId == 0)
                    dest.AccountTypeId = null;

                if (src.BuildingTypeId == 0)
                    dest.BuildingTypeId = null;

                if (src.DensityId == 0)
                    dest.DensityId = null;

                if (src.TypeStructuresMaterialsId == 0)
                    dest.TypeStructuresMaterialsId = null;

                //DateTime dt = MyFunctions.ConvertIntPersinDateToMiladiDate(src.DateConstruction.GetValueOrDefault());
                //dest.DateConstruction = DateTime.Now;

            });

            #endregion

            #region Asnaf_Avarez

            CreateMap<Asnaf_Avarez, Asnaf_AvarezViewModel>().ReverseMap();

            #endregion

            #region v_AsnafAvarez

            CreateMap<v_AsnafAvarez, v_AsnafAvarezViewModel>().ReverseMap();

            #endregion

            #region sabetha

            CreateMap<TabagheSort, byte?>().ConvertUsing(value => (byte?)value);
            CreateMap<byte?, TabagheSort>().ConvertUsing(value => (TabagheSort)value);

            #endregion

            #region v_Made100_RayOnKhalaf

            CreateMap<v_Made100_RayOnKhalaf, v_Made100_RayOnKhalafViewModel>().ReverseMap();

            #endregion

        }

    }
}