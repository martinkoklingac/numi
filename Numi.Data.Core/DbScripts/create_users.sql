DO $$
DECLARE _tablename VARCHAR(100) := 'users';

BEGIN
IF EXISTS(SELECT * FROM pg_tables AS T WHERE T.tablename = _tablename) THEN
	-- Add alter statements
	RAISE NOTICE 'Table [%] already exists', _tablename;
	
ELSE
	-- Add create statements
	RAISE NOTICE 'Table [%] doe not exist', _tablename;
	RAISE NOTICE 'Creating table [%] doe not exist', _tablename;

	CREATE TABLE public.users
    (
        id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
        username character varying(50) COLLATE pg_catalog."default" NOT NULL,
        password character(48) COLLATE pg_catalog."default" NOT NULL,
        email character varying(300) COLLATE pg_catalog."default" NOT NULL,
        CONSTRAINT pk_users_id PRIMARY KEY (id)
    )

    TABLESPACE pg_default;

    ALTER TABLE public.users
        OWNER to postgres;

    GRANT ALL ON TABLE public.users TO postgres;

END IF;

END $$;
