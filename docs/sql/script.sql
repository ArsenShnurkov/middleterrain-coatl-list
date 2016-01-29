-- list databases:
-- psql --list
-- execute script:
-- psql --username=postgres --dbname=test --file=/home/sabayon_mate/Desktop/dbscript/script.sql
-- The DO statement was added in PostgreSQL 9.0, i have 9.4.5


DO $$
DECLARE var_table_name VARCHAR;
BEGIN

	var_table_name := 'table1';

	EXECUTE format('IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
	WHERE table_catalog = ''test'' AND table_schema=''public'' AND table_type = ''BASE TABLE'' AND table_name=''%s'' FETCH FIRST 1 ROWS ONLY )
	
	BEGIN 	DROP TABLE ''%s''; END;
	', var_table_name, var_table_name);
	
	EXECUTE format('CREATE TABLE %s
	(
		record_id INTEGER,
		some_content INTEGER
	);', var_table_name);


END;
$$
LANGUAGE plpgsql;

-- IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE table_catalog = 'test' AND table_schema='public' AND table_type = 'BASE TABLE' AND table_name='table1' FETCH FIRST 1 ROWS ONLY ) THEN DROP TABLE 'table1'; END IF;