DROP TABLE IF EXISTS 'default_right';
DROP TABLE IF EXISTS 'right';
DROP TABLE IF EXISTS 'permission';
DROP TABLE IF EXISTS 'advertisement_fact';
DROP TABLE IF EXISTS 'job_advertisement_distribution_channel';
DROP TABLE IF EXISTS 'vacancy';
DROP TABLE IF EXISTS 'requirement';
DROP TABLE IF EXISTS 'benefit';
DROP TABLE IF EXISTS 'currency_value';
DROP TABLE IF EXISTS 'currency';
DROP TABLE IF EXISTS 'office';
DROP TABLE IF EXISTS 'communication_type';
DROP TABLE IF EXISTS 'legal_subject_contact';
DROP TABLE IF EXISTS 'ownership_share';
DROP TABLE IF EXISTS 'company';
DROP TABLE IF EXISTS 'website';
DROP TABLE IF EXISTS 'government';
DROP TABLE IF EXISTS 'ai';
DROP TABLE IF EXISTS 'human';
DROP TABLE IF EXISTS 'legal_subject';
DROP TABLE IF EXISTS 'legal_subject_types';
DROP TABLE IF EXISTS 'executor';
DROP TABLE IF EXISTS 'executor_types';
DROP TABLE IF EXISTS 'obj_which_can_be_owned';
DROP TABLE IF EXISTS 'obj_which_can_be_owned_types';
DROP TABLE IF EXISTS 'country';
DROP TABLE IF EXISTS 'federal_district';
DROP TABLE IF EXISTS 'municipal_district';
DROP TABLE IF EXISTS 'territory';
DROP TABLE IF EXISTS 'territory_types';
DROP TABLE IF EXISTS 'separation_line';
DROP TABLE IF EXISTS 'location_vertex';
DROP TABLE IF EXISTS 'dimension_formula_item';
DROP TABLE IF EXISTS 'dimension_formula';
DROP TABLE IF EXISTS 'notes_predcessors_array';
DROP TABLE IF EXISTS 'notes';
DROP TABLE IF EXISTS 'markup_item';
DROP TABLE IF EXISTS 'obj_which_can_be_commented';
DROP TABLE IF EXISTS 'obj_which_can_be_commented_types';
DROP TABLE IF EXISTS 'text_for_markup';
DROP TABLE IF EXISTS 'obj_which_can_be_named';
DROP TABLE IF EXISTS 'obj_which_can_be_named_types';
DROP TABLE IF EXISTS 'translation_set';
DROP TABLE IF EXISTS 'translation_unit';
DROP TABLE IF EXISTS 'word_in_language_and_notation';
DROP TABLE IF EXISTS 'language';
DROP TABLE IF EXISTS 'notation';

CREATE TABLE notation (
    notation_pk INTEGER
);

CREATE TABLE language (
    language_pk INTEGER
);

CREATE TABLE word_in_language_and_notation (
    word_in_language_and_notation_pk INTEGER,
    word VARCHAR
);

CREATE TABLE translation_unit (
    translation_unit_pk INTEGER
);

CREATE TABLE translation_set (
    translation_set_pk INTEGER
);

CREATE TABLE obj_which_can_be_named_types (
    obj_which_can_be_named_types_pk INTEGER,
    child_table_name VARCHAR
);

CREATE TABLE obj_which_can_be_named (
    obj_which_can_be_named_pk INTEGER,
    obj_which_can_be_named_types_fk INTEGER
);

CREATE TABLE text_for_markup (
    text_for_markup_pk INTEGER,
    text VARCHAR
);

CREATE TABLE obj_which_can_be_commented_types (
    obj_which_can_be_commented_types_pk INTEGER,
    child_table_name VARCHAR
);

CREATE TABLE obj_which_can_be_commented (
    obj_which_can_be_commented_pk INTEGER,
    obj_which_can_be_commented_types_fk INTEGER,
    obj_which_can_be_named_fk INTEGER
);

CREATE TABLE markup_item (
    markup_item_pk INTEGER,
    segment_start DECIMAL,
    segment_length DECIMAL,
    obj_which_can_be_commented_fk INTEGER
);

CREATE TABLE notes (
    notes_pk INTEGER
);

CREATE TABLE notes_predcessors_array (
    notes_predcessors_array_pk INTEGER
);

CREATE TABLE dimension_formula (
    dimension_formula_pk INTEGER
);

CREATE TABLE dimension_formula_item (
    dimension_formula_item_pk INTEGER,
    power_upper DECIMAL,
    power_lower DECIMAL
);

CREATE TABLE location_vertex (
    location_vertex_pk INTEGER,
    coordinates VARCHAR
);

CREATE TABLE separation_line (
    separation_line_pk INTEGER
);

CREATE TABLE territory_types (
    territory_types_pk INTEGER,
    child_table_name VARCHAR
);

CREATE TABLE territory (
    territory_pk INTEGER,
    obj_which_can_be_named_fk INTEGER,
    territory_types_fk INTEGER
);

CREATE TABLE municipal_district (
    municipal_district_pk INTEGER,
    territory_fk INTEGER
);

CREATE TABLE federal_district (
    federal_district_pk INTEGER,
    territory_fk INTEGER
);

CREATE TABLE country (
    country_pk INTEGER,
    territory_fk INTEGER
);

CREATE TABLE obj_which_can_be_owned_types (
    obj_which_can_be_owned_types_pk INTEGER,
    child_table_name VARCHAR
);

CREATE TABLE obj_which_can_be_owned (
    obj_which_can_be_owned_pk INTEGER,
    description VARCHAR,
    obj_which_can_be_commented_fk INTEGER,
    obj_which_can_be_owned_types_fk INTEGER
);

CREATE TABLE executor_types (
    executor_types_pk INTEGER,
    child_table_name VARCHAR
);

CREATE TABLE executor (
    executor_pk INTEGER,
    obj_which_can_be_commented_fk INTEGER,
    executor_types_fk INTEGER
);

CREATE TABLE legal_subject_types (
    legal_subject_types_pk INTEGER,
    child_table_name VARCHAR
);

CREATE TABLE legal_subject (
    legal_subject_pk INTEGER,
    obj_which_can_be_commented_fk INTEGER,
    obj_which_can_be_named_fk INTEGER,
    legal_subject_types_fk INTEGER
);

CREATE TABLE human (
    human_pk INTEGER,
    executor_fk INTEGER,
    legal_subject_fk INTEGER
);

CREATE TABLE ai (
    ai_pk INTEGER,
    obj_which_can_be_commented_fk INTEGER,
    executor_fk INTEGER
);

CREATE TABLE government (
    government_pk INTEGER,
    country_code VARCHAR,
    obj_which_can_be_named_fk INTEGER
);

CREATE TABLE website (
    website_pk INTEGER,
    url VARCHAR,
    description VARCHAR,
    obj_which_can_be_owned_fk INTEGER
);

CREATE TABLE company (
    company_pk INTEGER,
    agreement VARCHAR,
    mission VARCHAR,
    government_code VARCHAR,
    description VARCHAR,
    obj_which_can_be_owned_fk INTEGER,
    legal_subject_fk INTEGER
);

CREATE TABLE ownership_share (
    ownership_share_pk INTEGER,
    percentage_upper DECIMAL,
    percentage_lower DECIMAL
);

CREATE TABLE legal_subject_contact (
    legal_subject_contact_pk INTEGER,
    contact_info VARCHAR,
    obj_which_can_be_commented_fk INTEGER
);

CREATE TABLE communication_type (
    communication_type_pk INTEGER,
    obj_which_can_be_commented_fk INTEGER,
    obj_which_can_be_named_fk INTEGER
);

CREATE TABLE office (
    office_pk INTEGER,
    office_name VARCHAR,
    office_address VARCHAR,
    description VARCHAR,
    obj_which_can_be_owned_fk INTEGER
);

CREATE TABLE currency (
    currency_pk INTEGER,
    obj_which_can_be_named_fk INTEGER
);

CREATE TABLE currency_value (
    currency_value_pk INTEGER,
    date DATE,
    rate_upper DECIMAL,
    rate_lower DECIMAL,
    source_value_of_rate VARCHAR
);

CREATE TABLE benefit (
    benefit_pk INTEGER,
    obj_which_can_be_commented_fk INTEGER
);

CREATE TABLE requirement (
    requirement_pk INTEGER,
    req_name VARCHAR,
    obj_which_can_be_commented_fk INTEGER
);

CREATE TABLE vacancy (
    vacancy_pk INTEGER,
    compensation_upper DECIMAL,
    compensation_lower DECIMAL,
    official_url VARCHAR,
    obj_which_can_be_commented_fk INTEGER
);

CREATE TABLE job_advertisement_distribution_channel (
    job_advertisement_distribution_channel_pk INTEGER,
    description VARCHAR,
    obj_which_can_be_owned_fk INTEGER
);

CREATE TABLE advertisement_fact (
    advertisement_fact_pk INTEGER,
    unofficial_url VARCHAR,
    obj_which_can_be_commented_fk INTEGER
);

CREATE TABLE permission (
    permission_pk INTEGER
);

CREATE TABLE right (
    right_pk INTEGER
);

CREATE TABLE default_right (
    default_right_pk INTEGER
);
