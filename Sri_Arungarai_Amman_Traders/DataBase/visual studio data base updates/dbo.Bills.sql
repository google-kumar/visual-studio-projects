CREATE TABLE [dbo].[Bills] (
    [BillNo]       INT          NOT NULL Identity(1,1),
    [BillDate]     VARCHAR (15) NULL,
    [CustomerName] VARCHAR (20) NOT NULL,
    [PhoneNumber]  BIGINT       NOT NULL,
    [BillAmount]   FLOAT (53)   NOT NULL,
    [BillPaid]     FLOAT (53)   NOT NULL ,
    PRIMARY KEY CLUSTERED ([BillNo] ASC)
);

