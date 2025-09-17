
CREATE OR REPLACE FORCE EDITIONABLE VIEW "SYSTEM"."VW_SYNC_PRODUCTS" 
(
    ID,
    NAME,
    DESCRIPTION,
    CATEGORY,
    UNIT_PRICE,
    STOCK_QUANTITY,
    UNIT_MEASURE,
    MANUFACTURER,
    CREATED_AT,
    OPERATION_ID,
    HASH_VALUE,
    ENTITY_ID
) AS
SELECT   
            tbl.ID,
            tbl.NAME,
            tbl.DESCRIPTION,
            tbl.CATEGORY,
            tbl.UNIT_PRICE,
            tbl.STOCK_QUANTITY,
            tbl.UNIT_OF_MEASURE,
            tbl.MANUFACTURER,
            tbl.CREATED_AT,
            1 AS OPERATION_ID,
            sync_pkg.hash_product(tbl.ID, tbl.NAME) AS HASH_VALUE,
            1 AS ENTITY_ID
         FROM SYSTEM.products      tbl
    LEFT JOIN SYSTEM.sync_hashes   shs ON ( tbl.id = shs.RECORD_ID AND shs.ENTITY_ID = 1)
      WHERE shs.HASH_VALUE IS NULL
      
UNION ALL

SELECT   
            tbl.ID,
            tbl.NAME,
            tbl.DESCRIPTION,
            tbl.CATEGORY,
            tbl.UNIT_PRICE,
            tbl.STOCK_QUANTITY,
            tbl.UNIT_OF_MEASURE,
            tbl.MANUFACTURER,
            tbl.CREATED_AT,
            2 AS OPERATION_ID,
            sync_pkg.hash_product(tbl.ID, tbl.NAME) AS HASH_VALUE,
            1 AS ENTITY_ID
         FROM SYSTEM.products      tbl
         JOIN SYSTEM.sync_hashes   shs ON ( tbl.id = shs.RECORD_ID AND shs.ENTITY_ID = 1)
      WHERE shs.HASH_VALUE <> sync_pkg.hash_product(tbl.ID, tbl.NAME)
      
UNION ALL

SELECT   
            tbl.ID,
            tbl.NAME,
            tbl.DESCRIPTION,
            tbl.CATEGORY,
            tbl.UNIT_PRICE,
            tbl.STOCK_QUANTITY,
            tbl.UNIT_OF_MEASURE,
            tbl.MANUFACTURER,
            tbl.CREATED_AT,
            3 AS OPERATION_ID,
            sync_pkg.hash_product(tbl.ID, tbl.NAME) AS HASH_VALUE,
            1 AS ENTITY_ID
         FROM SYSTEM.sync_hashes   shs
    LEFT JOIN SYSTEM.products      tbl ON ( tbl.id = shs.RECORD_ID AND shs.ENTITY_ID = 1)
      WHERE shs.operation_id <> 3
        AND tbl.ID IS NULL;
