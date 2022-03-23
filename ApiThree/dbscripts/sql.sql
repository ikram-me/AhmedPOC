
\connect postgres

CREATE TABLE transmwercpmtnradiolinkpower
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





CREATE TABLE   transmwercpmtnwanethtraffic 
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


ALTER TABLE transmwercpmtnwanethtraffic OWNER TO postgres;
ALTER TABLE transmwercpmtnradiolinkpower OWNER TO postgres;

