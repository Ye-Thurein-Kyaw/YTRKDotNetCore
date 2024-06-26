﻿namespace YTRKDotNetCore.PizzaApi.Features.Queries
{
    public class PizzaQuerry
    {
        public static string PizzaOrderQuery { get; } =
            @"select po.*, p.Pizza, p.Price from [dbo].[Tbl_PizzaOrder] po
                inner join [dbo].[Tbl_Pizza] p on p.PizzaId = po.PizzaId
                where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";


        public static string PizzaOrderDetailQuery { get; } =
            @"select pod.*,pe.PizzaExtraName, pe.Price from [dbo].[Tbl_PizzaOrderDetail] pod
                inner join [dbo].[Tbl_PizzaExtra] pe on pod.PizzaExtraId = pe.PizzaExtraId
                where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }
}
