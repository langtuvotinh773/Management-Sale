using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.Commons
{
   public static class SettingCodeDB
    {
        public const int Morethan100Records = 100;
        public const string ItemCode_Promotion = "unknown.png";

        public const string USERNAME_User = "user";
        public const string PASSWORD_User = "0ba05e0f50120940fe0a50cb04e0ad0ea0530060f30ca03b";

        public const string USERNAME_Admin = "admin";
        public const string PASSWORD_Admin = "0d905f01605309f0a60000000820f002b0620e30b10dc06d";

        public const int NotPermission = 0;
        public const int Permission = 1;
        public const int ExceptionPermission = 2;

        public const string TypePromotion_No = "Không Khuyến Mãi";
        public const string TypePromotion_Discount = "GIẢM GIÁ";
        public const string TypePromotion_Product = "TẶNG SẢN PHẨM";
        public const string TypePromotion_Product_Discount = "GIẢM GIÁ - TẶNG SẢN PHẨM";


        public enum listScreens
        { 
            frmMain,
            frmEditOrders,
            frmCreatNewImport,
            frmNewOrders,
            uctOrders,
            uctImportOrder
        };
        public enum listActions
       {
           Logon = 0,
           Create = 1,
           Update = 2,
           Delete = 3,
           Import = 4,
           Refresh = 5
       };


    }
}
