-- psql --username=postgres --dbname=test --file=/var/calculate/remote/distfiles/egit-src/middleterrain-coatl-list.git/docs/sql/script2.sql
DROP TABLE IF EXISTS rights_event;
DROP TABLE IF EXISTS rights_state;
DROP TABLE IF EXISTS notes_reply_array_item;
DROP TABLE IF EXISTS notes_reply_array_state;
DROP TABLE IF EXISTS notes_event;
DROP TABLE IF EXISTS notes_state;
DROP TABLE IF EXISTS human_event;
DROP TABLE IF EXISTS human_state;
DROP TABLE IF EXISTS integer_quantities_value_change_event;
DROP TABLE IF EXISTS dimension_definition_state;
DROP TABLE IF EXISTS integer_quantities_event;
DROP TABLE IF EXISTS integer_quantities_state;
DROP TABLE IF EXISTS dimension_definition_event;
DROP TABLE IF EXISTS dimension_definition_part_state;
DROP TABLE IF EXISTS currency_event;
DROP TABLE IF EXISTS currency_state;
DROP TABLE IF EXISTS markup_array_item_state; -- cache, events are not important
DROP TABLE IF EXISTS benefits_array_item_event;
DROP TABLE IF EXISTS benefits_array_item_state;
DROP TABLE IF EXISTS benefits_array_event;
DROP TABLE IF EXISTS benefits_array_state;
DROP TABLE IF EXISTS requirements_array_item_event;
DROP TABLE IF EXISTS requirements_array_item_state;
DROP TABLE IF EXISTS requirements_array_event;
DROP TABLE IF EXISTS requirements_array_state;
DROP TABLE IF EXISTS language_registry_item_translation_event;
DROP TABLE IF EXISTS language_registry_item_translation_state;
DROP TABLE IF EXISTS benefits_registry_item_event;
DROP TABLE IF EXISTS benefits_registry_item_state;
DROP TABLE IF EXISTS requirements_registry_item_event;
DROP TABLE IF EXISTS requirements_registry_item_state;
DROP TABLE IF EXISTS currency_registry_item_event;
DROP TABLE IF EXISTS currency_registry_item_state;
DROP TABLE IF EXISTS language_registry_item_event;
DROP TABLE IF EXISTS language_registry_item_state;
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

DROP DOMAIN IF EXISTS NINHERITANCE;
DROP DOMAIN IF EXISTS NARRAY;
DROP DOMAIN IF EXISTS NAGGREGATE;
DROP DOMAIN IF EXISTS NREFERENCE;
DROP DOMAIN IF EXISTS NKEY;

CREATE DOMAIN NKEY AS INTEGER; -- unique identifier (why do i need them?)
CREATE DOMAIN NREFERENCE AS INTEGER; -- reference to item (or item state) in classifier
CREATE DOMAIN NARRAY AS INTEGER; -- aggregated array
CREATE DOMAIN NAGGREGATE AS INTEGER; -- aggregated value
CREATE DOMAIN NINHERITANCE AS INTEGER; -- fk to parent's part of object

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
	company_state_fk NREFERENCE, -- only company can belong to humans and corporations
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

-- множества

-- множество языков
CREATE TABLE language_registry_item_state
(
	language_registry_state_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE language_registry_item_event
(
	currency_registry_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE currency_registry_item_state
(
	currency_registry_state_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE currency_registry_item_event
(
	currency_registry_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE requirements_registry_item_state
(
	requirements_registry_state_id NKEY,
	record_stamp TIMESTAMP,
	requirement_text VARCHAR, -- number of records in array
	notes_agg NAGGREGATE
);

CREATE TABLE requirements_registry_item_event
(
	requirements_registry_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE benefits_registry_item_state
(
	requirements_registry_state_id NKEY,
	record_stamp TIMESTAMP,
	requirement_text VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE language_registry_item_translation_state
(
	language_registry_item_translation_state_id NKEY,
	record_stamp TIMESTAMP,
	language_registry_state_object_fk NREFERENCE,
	language_registry_state_language_fk NREFERENCE,
	name_rules VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE language_registry_item_translation_event
(
	language_registry_item_translation_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE benefits_registry_item_event
(
	benefits_registry_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE requirements_array_state
(
	requirements_array_state_id NKEY,
	record_stamp TIMESTAMP,
	advertisement_fact_state_fk NREFERENCE,
	records_count VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE requirements_array_event
(
	requirements_array_event_id NKEY,
	record_stamp TIMESTAMP,
	position INTEGER,
	notes_agg NAGGREGATE
);

CREATE TABLE requirements_array_item_state
(
	requirements_array_item_state_id NKEY,
	record_stamp TIMESTAMP,
	requirements_array_state_fk NREFERENCE,
	requirements_registry_state_fk NREFERENCE,
	markup_array_item_state_fk NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE requirements_array_item_event
(
	requirements_array_item_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE benefits_array_state
(
	benefits_array_state_id NKEY,
	record_stamp TIMESTAMP,
	advertisement_fact_state_fk NREFERENCE,
	records_count VARCHAR,
	notes_agg NAGGREGATE
);

CREATE TABLE benefits_array_event
(
	benefits_array_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE benefits_array_item_state
(
	benefits_array_item_state_id NKEY,
	record_stamp TIMESTAMP,
	position INTEGER,
	benefits_array_state_fk NREFERENCE,
	benefits_registry_state_fk NREFERENCE,
	markup_array_item_state_fk NREFERENCE,
	notes_agg NAGGREGATE
);

CREATE TABLE benefits_array_item_event
(
	benefits_array_item_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE markup_array_item_state
(
	markup_array_item_state_id NKEY,
	record_stamp TIMESTAMP,
	advertisement_fact_event_fk NREFERENCE,
	segment_start INTEGER,
	segment_length INTEGER,
	notes_agg NAGGREGATE
);

CREATE TABLE currency_event
(
	benefits_array_item_event_id NKEY,
	record_stamp TIMESTAMP,
	notes_agg NAGGREGATE
);

CREATE TABLE currency_state
(
	currency_state_id NKEY,
	record_stamp TIMESTAMP,
	language_registry_item_state_object_fk NREFERENCE,
	language_registry_item_state_ NREFERENCE,
	upper_part DECIMAL,
	lower_part DECIMAL,
	source_value VARCHAR,
	source_date DATE,
	notes_agg NAGGREGATE
);

-- формула размерности

CREATE TABLE dimension_definition_state
(
	dimension_definition_id INTEGER,
	dimension_definition_change_id INTEGER,
	change_comment VARCHAR
);

CREATE TABLE dimension_definition_part_state
(
	dimension_definition_id INTEGER, -- parent array object
	position INTEGER, -- позиция в формуле
	unit_fk NREFERENCE, -- название единицы изменения
	power_of_dimension_upper DECIMAL, -- в какую степень возводить (верхняя часть дроби)
	power_of_dimension_lover DECIMAL, -- в какую степень возводить (нижняя часть дроби)
	dimension_definition_part_state_id INTEGER -- just id
);

CREATE TABLE dimension_definition_event
(
	dimension_definition_event_id INTEGER, -- идентификатор конкретной операции (не используется?)
	change_date TIMESTAMP, -- by dataserver clocks
	change_comment varchar,
	dimension_definition_id INTEGER, -- что стало после изменения
	change_type_fk NREFERENCE -- тип изменения (create, delete, change)
);

-- целые величины (например рубли)

CREATE TABLE integer_quantities_state
(
	quantity_id INTEGER, -- прослеживает идентичность этой ветки изменений (неуникальное)
	integer_quantities_change_id INTEGER,  -- изменение, которым установлено текущее значение
	quantity_value INTEGER,
	dimension_definition_fk NREFERENCE, -- формула размерности величины
	notes_agg NAGGREGATE,
	integer_quantities_state_id NKEY
);

CREATE TABLE integer_quantities_event
(
	integer_quantities_event_id integer,
	change_date TIMESTAMP, -- by dataserver clocks
	change_type_fk NREFERENCE,
	change_comment VARCHAR,
	notes_agg NAGGREGATE,
	quantity_event_id INTEGER -- идентификатор конкретной операции (не используется?)
);

CREATE TABLE integer_quantities_value_change_event
(
	integer_quantities_event_fk NINHERITANCE,
	quantity_current_fk NREFERENCE, -- current state
	quantity_previous_fk NREFERENCE, -- previous state
	-- comment is inherited
	quantity_event_id INTEGER -- идентификатор конкретной операции (не используется?)
);

-- нужна ещё таблицы-справочники:
--  видов величин (например рубли)
--  видов операций по разновидностям объектов (создание, удаление, изменение значения ячейки в столбце [связанной] записи)

-- what distinguishes human from corporation in the system?
-- can corporations own access rights to operations on this site?
-- should the system track delegation of rights from corporation to specific human?
-- humans can own corporations, but not another humans. Corporations can own other corporations (see ownership_share_state)
-- humans has concisioness, corporations doesn't.
CREATE TABLE human_state
(
	legal_subject_state_fk NINHERITANCE,
	humans_state_id NKEY
);

CREATE TABLE human_event
(
	legal_subject_state_event_fk NINHERITANCE,
	humans_event_id NKEY
);

CREATE TABLE notes_state
(
	record_stamp TIMESTAMP,
	owners_set_arr NARRAY, -- who signed this version of note
	note_content VARCHAR,
	notes_state_id NKEY
);

CREATE TABLE notes_event
(
	record_stamp TIMESTAMP,
	notes_event_type_ref NREFERENCE,
	notes_event_id NKEY
);

CREATE TABLE notes_reply_array_state
(
	record_stamp TIMESTAMP,
	notes_state_fk NREFERENCE,
	notes_reply_array_state_id NKEY
);

CREATE TABLE notes_reply_array_item
(
	record_stamp TIMESTAMP,
	note_content VARCHAR,
	notes_reply_array_state_fk NREFERENCE, -- parent array
	predcessor_position INTEGER,
	notes_state_predcessor_fk NREFERENCE, -- это ответ и на ваш вопрос...
	notes_state_successor_fk NREFERENCE,
	notes_reply_array_item_id NKEY
);

-- чего ещё не хватает?
-- 3) прав владения, доступа, распоряжения
-- группа прав (роль)
-- группа объектов (шаблон доступа), вообще описание объекта доступа
-- (таблица + колонка + ID строки или обобщенный SQL-запрос?)
-- 4) собственно справочника прав

CREATE TABLE rights_state
(
	owners_set_arr NARRAY, -- who have this right
	-- object?
	rights_type_ref NREFERENCE, -- which right is granted
	record_stamp TIMESTAMP,
	rights_state_id NKEY
);

CREATE TABLE rights_event
(
	record_stamp TIMESTAMP,
	rights_event_type_ref NREFERENCE,
	rights_event_id NKEY
);
