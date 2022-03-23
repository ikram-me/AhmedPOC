
\connect postgres


CREATE TABLE TRANS_MW_AGG_SLOT_HOURLY
(
          
   network_sid SERIAL PRIMARY KEY,
RSL_DEVIATION VARCHAR (50) NOT NULL,
checkpoint VARCHAR (50) NOT NULL
 
);

CREATE TABLE TRANS_MW_ERC_PM_TN_RADIO_LINK_POWER 
(
   network_sid SERIAL PRIMARY KEY,
NeId VARCHAR (50) ,
   Object  VARCHAR (50)   ,
Time  VARCHAR (50)    ,
Interval  VARCHAR (50)    ,
Direction  VARCHAR (50)    ,
NeAlias  VARCHAR (50)    ,
NeType  VARCHAR (50)    ,
RxLevelBelowTS1  VARCHAR (50)    ,
RxLevelBelowTS2  VARCHAR (50)    ,
MinRxLevel  VARCHAR (50)    ,
MaxRxLevel  VARCHAR (50)    ,
TxLevelAboveTS1  VARCHAR (50)    ,
MinTxLevel  VARCHAR (50)    ,
MaxTxLevel  VARCHAR (50)    ,
FailureDescription  VARCHAR (50)  
);

CREATE TABLE TRANS_MW_ERC_PM_WAN_RFINPUTPOWER

(
network_sid SERIAL PRIMARY KEY,
NeId VARCHAR (50) ,
NodeName  VARCHAR (50) ,
Object  VARCHAR (50)  ,
Time  VARCHAR (50)  ,
Interval  VARCHAR (50) ,
Direction  VARCHAR (50)  ,
NeAlias  VARCHAR (50)  ,
NeType  VARCHAR (50)  ,
RFInputPower  VARCHAR (50)  ,
MeanRxLevel1m  VARCHAR (50)  ,
TID  VARCHAR (50)  ,
FarEndTID  VARCHAR (50)  );


ALTER TABLE TRANS_MW_ERC_PM_WAN_RFINPUTPOWER OWNER TO postgres;
ALTER TABLE TRANS_MW_ERC_PM_TN_RADIO_LINK_POWER OWNER TO postgres;
ALTER TABLE TRANS_MW_AGG_SLOT_HOURLY OWNER TO postgres;






