-- psql --username=postgres --dbname=test --file=/home/sabayon_mate/Desktop/dbscript/script2.sql
--     execute script
-- psql --list
--     list databases
-- The DO statement was added in PostgreSQL 9.0, i have 9.4.5
-- SQL 2011, 11.31, <drop table statement>
-- <drop table statement> ::= DROP TABLE <table name> <drop behavior>
-- IF EXISTS is not standard; different platforms might support it with different syntax, or not support it at all.
-- http://stackoverflow.com/a/9565901/1709408
--DROP TABLE IF EXISTS table1;
--CREATE TABLE table1
--(
--	record_id INTEGER,
--	mystamp TIMESTAMP,
--	some_content VARCHAR
--);
-- Adding a unique constraint will automatically create 
-- a unique btree index on the column or group of columns used in the constraint.
-- PostgreSQL doesn't automatically create indexes on foreign key columns that reference other columns
-- http://stackoverflow.com/questions/970562/postgres-and-indexes-on-foreign-keys-and-primary-keys
-- Technically, a primary key constraint is simply a combination of a unique constraint and a not-null constraint.
-- Add not null constraint
--ALTER TABLE table1 ALTER COLUMN record_id SET NOT NULL;
-- Add unique constraint
--ALTER TABLE table1 ADD CONSTRAINT table1_con1 UNIQUE(record_id);
-- create index (for sorting by time)
--CREATE INDEX table1_idx1 ON table1 (mystamp);
--DROP INDEX
-- Add foreign key (http://www.postgresql.org/docs/9.4/static/sql-altertable.html)
-- ALTER TABLE distributors ADD CONSTRAINT distfk FOREIGN KEY (address) REFERENCES addresses (address);
-- ALTER TABLE distributors ADD CONSTRAINT distfk FOREIGN KEY (address) REFERENCES addresses (address) NOT VALID;
-- ALTER TABLE distributors VALIDATE CONSTRAINT distfk;
-- If the constraint is marked NOT VALID, the potentially-lengthy initial check to verify that all rows in the table satisfy the constraint is skipped.
-- The constraint will still be enforced against subsequent inserts or updates (that is, they'll fail unless there is a matching row in the referenced table).
-- But the database will not assume that the constraint holds for all rows in the table, until it is validated by using the VALIDATE CONSTRAINT option.
-- ALTER TABLE distributors DROP CONSTRAINT [ IF EXISTS ]  constraint_name [ RESTRICT | CASCADE ]
-- RESTRICT = Refuse to drop constraint if there are any dependent objects. This is the default behavior.

DROP TABLE IF EXISTS advertisement_fact_event;
DROP TABLE IF EXISTS advertisement_fact_state;
DROP TABLE IF EXISTS vacancy_event;
DROP TABLE IF EXISTS vacancy_state;
DROP TABLE IF EXISTS ownership_share_event;
DROP TABLE IF EXISTS ownership_share_state;
DROP TABLE IF EXISTS communication_type_event;
DROP TABLE IF EXISTS communication_type_state;
DROP TABLE IF EXISTS government_event;
DROP TABLE IF EXISTS government_state;
DROP TABLE IF EXISTS legal_subject_contact_event;
DROP TABLE IF EXISTS legal_subject_contact_state;
DROP TABLE IF EXISTS legal_subject_event;
DROP TABLE IF EXISTS legal_subject_state;
DROP TABLE IF EXISTS job_advertisement_distribution_channel_event;
DROP TABLE IF EXISTS job_advertisement_distribution_channel_state;
DROP TABLE IF EXISTS office_event;
DROP TABLE IF EXISTS office_state;
DROP TABLE IF EXISTS company_event;
DROP TABLE IF EXISTS company_state;

DROP DOMAIN IF EXISTS NARRAY;
DROP DOMAIN IF EXISTS NAGGREGATE;
DROP DOMAIN IF EXISTS NREFERENCE;
DROP DOMAIN IF EXISTS NKEY;

CREATE DOMAIN NKEY AS INTEGER; -- unique identifier (why do i need them?)
CREATE DOMAIN NREFERENCE AS INTEGER; -- reference to item (or item state) in classifier
CREATE DOMAIN NARRAY AS INTEGER; -- aggregated array
CREATE DOMAIN NAGGREGATE AS INTEGER; -- aggregated value

CREATE TABLE company_state
(
	company_state_id NKEY,
	record_stamp TIMESTAMP,
	url VARCHAR,
	mission VARCHAR,
	government_code VARCHAR,
	official_name VARCHAR,
	owners_set_arr NARRAY,
	notes_agg NAGGREGATE
);

CREATE TABLE company_event
(
	company_event_id NKEY,
	record_stamp TIMESTAMP,
	company_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE office_state
(
	office_state_id NKEY,
	record_stamp TIMESTAMP,
	owner_ref NREFERENCE, -- the right of ownership
	user_ref NREFERENCE, -- the right to use
	notes_agg NAGGREGATE
);

CREATE TABLE office_event
(
	office_event_id NKEY,
	record_stamp TIMESTAMP,
	office_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE legal_subject_state
(
	legal_subject_id NKEY,
	record_stamp TIMESTAMP,
	full_name VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE legal_subject_event
(
	legal_subject_event_id NKEY,
	record_stamp TIMESTAMP,
	legal_subject_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE legal_subject_contact_state
(
	legal_subject_contact_state_id NKEY,
	record_stamp TIMESTAMP,
	legal_subject_state_fk NREFERENCE,
	communication_type_state_fk NREFERENCE,
	contact_info VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE legal_subject_contact_event
(
	legal_subject_contact_event_id NKEY,
	record_stamp TIMESTAMP,
	legal_subject_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE government_state
(
	government_event_id NKEY,
	record_stamp TIMESTAMP,
	official_name VARCHAR,
	country_code VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE government_event
(
	government_event_id NKEY,
	record_stamp TIMESTAMP,
	government_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE communication_type_state
(
	communication_type_state_id NKEY,
	record_stamp TIMESTAMP,
	channel_name VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE communication_type_event
(
	communication_type_event_id NKEY,
	record_stamp TIMESTAMP,
	communication_type_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

INSERT INTO communication_type_state (channel_name) VALUES ('email');
INSERT INTO communication_type_state (channel_name) VALUES ('phone');
INSERT INTO communication_type_state (channel_name) VALUES ('jabber');
INSERT INTO communication_type_state (channel_name) VALUES ('xmpp');
INSERT INTO communication_type_state (channel_name) VALUES ('irc');

CREATE TABLE ownership_share_state
(
	ownership_share_state_id NKEY,
	record_stamp TIMESTAMP,
	company_state_fk NREFERENCE,
	legal_subject_state_fk NREFERENCE,
	agreement VARCHAR, -- reference to establishing agreement, which contain rules
	notes_agg NAGGREGATE
);

CREATE TABLE ownership_share_event
(
	ownership_share_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE vacancy_state
(
	vacancy_state_id NKEY,
	record_stamp TIMESTAMP,
	company_state_fk NREFERENCE,
	official_url VARCHAR,
	text_of_vacancy VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE vacancy_event
(
	vacancy_event_id NKEY,
	record_stamp TIMESTAMP,
	related_bodies NARRAY, -- contact person, owner of vacancy, originator of idea, interviewer and other roles
	notes_agg NAGGREGATE
);

CREATE TABLE job_advertisement_distribution_channel_state
(
	job_advertisement_distribution_channel_state_id NKEY,
	record_stamp TIMESTAMP,
	url VARCHAR,
	distributor_ref NREFERENCE, -- company which operates the channel
	notes_agg NAGGREGATE
);

CREATE TABLE job_advertisement_distribution_channel_event
(
	job_advertisement_distribution_channel_event_id NKEY,
	record_stamp TIMESTAMP,
	distribution_channel_event_type_ref NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE advertisement_fact_state
(
	advertisement_fact_state_id NKEY,
	record_stamp TIMESTAMP,
	job_advertisement_distribution_channel_state_fk NREFERENCE, -- reference to distribution channel
	url VARCHAR,
	text_of_advertisement VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE advertisement_fact_event
(
	advertisement_fact_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);
