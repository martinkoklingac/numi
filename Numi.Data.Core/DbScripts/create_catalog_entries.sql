DO $$
DECLARE _tablename VARCHAR(100) := 'catalog_entries';

BEGIN
IF EXISTS(SELECT * FROM pg_tables AS T WHERE T.tablename = _tablename) THEN
	-- Add alter statements
	RAISE NOTICE 'Table [%] already exists', _tablename;
	
ELSE
	-- Add create statements
	RAISE NOTICE 'Table [%] doe not exist', _tablename;
	RAISE NOTICE 'Creating table [%] doe not exist', _tablename;

	CREATE TABLE public.catalog_entries
    (
        id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
        CONSTRAINT pk_id PRIMARY KEY (id)
    )

    TABLESPACE pg_default;

    ALTER TABLE public.catalog_entries
        OWNER to postgres;

    GRANT ALL ON TABLE public.catalog_entries TO postgres;

END IF;

END $$;
