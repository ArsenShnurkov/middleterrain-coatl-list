DROP TABLE IF EXISTS "array_vacancy_benefit";
DROP TABLE IF EXISTS "array_vacancy_requirement";
DROP TABLE IF EXISTS "array_office_legal_subject_contact";
DROP TABLE IF EXISTS "array_company_website";
DROP TABLE IF EXISTS "array_country_language";
DROP TABLE IF EXISTS "array_country_federal_district";
DROP TABLE IF EXISTS "array_federal_district_municipal_district";
DROP TABLE IF EXISTS "array_notes_predcessors_array_obj_which_can_be_commented";
DROP TABLE IF EXISTS "array_language_notation";
DROP TABLE IF EXISTS "set_right_permission";
DROP TABLE IF EXISTS "set_right_dbobject";
DROP TABLE IF EXISTS "set_job_advertisement_distribution_channel_advertisement_fact";
DROP TABLE IF EXISTS "set_company_office";
DROP TABLE IF EXISTS "set_company_vacancy";
DROP TABLE IF EXISTS "set_company_ownership_share";
DROP TABLE IF EXISTS "set_government_executor";
DROP TABLE IF EXISTS "set_legal_subject_obj_which_can_be_owned";
DROP TABLE IF EXISTS "set_legal_subject_right";
DROP TABLE IF EXISTS "set_obj_which_can_be_owned_legal_subject";
DROP TABLE IF EXISTS "set_territory_separation_line";
DROP TABLE IF EXISTS "set_dimension_formula_dimension_formula_item";
DROP TABLE IF EXISTS "set_translation_set_translation_unit";
DROP TABLE IF EXISTS "set_notation_word_in_language_and_notation";
DROP TABLE IF EXISTS "set_notation_language";
DROP TABLE IF EXISTS "default_right";
DROP TABLE IF EXISTS "right";
DROP TABLE IF EXISTS "dbclass";
DROP TABLE IF EXISTS "dbobject";
DROP TABLE IF EXISTS "permission";
DROP TABLE IF EXISTS "advertisement_fact";
DROP TABLE IF EXISTS "job_advertisement_distribution_channel";
DROP TABLE IF EXISTS "vacancy";
DROP TABLE IF EXISTS "requirement";
DROP TABLE IF EXISTS "benefit";
DROP TABLE IF EXISTS "currency_value";
DROP TABLE IF EXISTS "currency";
DROP TABLE IF EXISTS "office";
DROP TABLE IF EXISTS "communication_type";
DROP TABLE IF EXISTS "legal_subject_contact";
DROP TABLE IF EXISTS "ownership_share";
DROP TABLE IF EXISTS "company";
DROP TABLE IF EXISTS "website";
DROP TABLE IF EXISTS "government";
DROP TABLE IF EXISTS "ai";
DROP TABLE IF EXISTS "human";
DROP TABLE IF EXISTS "legal_subject";
DROP TABLE IF EXISTS "legal_subject_types";
DROP TABLE IF EXISTS "executor";
DROP TABLE IF EXISTS "executor_types";
DROP TABLE IF EXISTS "obj_which_can_be_owned";
DROP TABLE IF EXISTS "obj_which_can_be_owned_types";
DROP TABLE IF EXISTS "country";
DROP TABLE IF EXISTS "federal_district";
DROP TABLE IF EXISTS "municipal_district";
DROP TABLE IF EXISTS "territory";
DROP TABLE IF EXISTS "territory_types";
DROP TABLE IF EXISTS "separation_line";
DROP TABLE IF EXISTS "location_vertex";
DROP TABLE IF EXISTS "dimension_formula_item";
DROP TABLE IF EXISTS "dimension_formula";
DROP TABLE IF EXISTS "notes_predcessors_array";
DROP TABLE IF EXISTS "notes";
DROP TABLE IF EXISTS "markup_item";
DROP TABLE IF EXISTS "obj_which_can_be_commented";
DROP TABLE IF EXISTS "obj_which_can_be_commented_types";
DROP TABLE IF EXISTS "text_for_markup";
DROP TABLE IF EXISTS "obj_which_can_be_named";
DROP TABLE IF EXISTS "obj_which_can_be_named_types";
DROP TABLE IF EXISTS "translation_set";
DROP TABLE IF EXISTS "translation_unit";
DROP TABLE IF EXISTS "word_in_language_and_notation";
DROP TABLE IF EXISTS "language";
DROP TABLE IF EXISTS "notation";

DROP SEQUENCE IF EXISTS "notation_ids";

DROP SEQUENCE IF EXISTS "language_ids";

DROP SEQUENCE IF EXISTS "word_in_language_and_notation_ids";

DROP SEQUENCE IF EXISTS "translation_unit_ids";

DROP SEQUENCE IF EXISTS "translation_set_ids";

DROP SEQUENCE IF EXISTS "obj_which_can_be_named_ids";

DROP SEQUENCE IF EXISTS "text_for_markup_ids";

DROP SEQUENCE IF EXISTS "markup_item_ids";

DROP SEQUENCE IF EXISTS "notes_ids";

DROP SEQUENCE IF EXISTS "notes_predcessors_array_ids";

DROP SEQUENCE IF EXISTS "obj_which_can_be_commented_ids";

DROP SEQUENCE IF EXISTS "dimension_formula_ids";

DROP SEQUENCE IF EXISTS "dimension_formula_item_ids";

DROP SEQUENCE IF EXISTS "location_vertex_ids";

DROP SEQUENCE IF EXISTS "separation_line_ids";

DROP SEQUENCE IF EXISTS "territory_ids";

DROP SEQUENCE IF EXISTS "municipal_district_ids";

DROP SEQUENCE IF EXISTS "federal_district_ids";

DROP SEQUENCE IF EXISTS "country_ids";

DROP SEQUENCE IF EXISTS "obj_which_can_be_owned_ids";

DROP SEQUENCE IF EXISTS "executor_ids";

DROP SEQUENCE IF EXISTS "legal_subject_ids";

DROP SEQUENCE IF EXISTS "human_ids";

DROP SEQUENCE IF EXISTS "ai_ids";

DROP SEQUENCE IF EXISTS "government_ids";

DROP SEQUENCE IF EXISTS "website_ids";

DROP SEQUENCE IF EXISTS "company_ids";

DROP SEQUENCE IF EXISTS "ownership_share_ids";

DROP SEQUENCE IF EXISTS "legal_subject_contact_ids";

DROP SEQUENCE IF EXISTS "communication_type_ids";

DROP SEQUENCE IF EXISTS "office_ids";

DROP SEQUENCE IF EXISTS "currency_ids";

DROP SEQUENCE IF EXISTS "currency_value_ids";

DROP SEQUENCE IF EXISTS "benefit_ids";

DROP SEQUENCE IF EXISTS "requirement_ids";

DROP SEQUENCE IF EXISTS "vacancy_ids";

DROP SEQUENCE IF EXISTS "job_advertisement_distribution_channel_ids";

DROP SEQUENCE IF EXISTS "advertisement_fact_ids";

DROP SEQUENCE IF EXISTS "permission_ids";

DROP SEQUENCE IF EXISTS "dbobject_ids";

DROP SEQUENCE IF EXISTS "dbclass_ids";

DROP SEQUENCE IF EXISTS "right_ids";

DROP SEQUENCE IF EXISTS "default_right_ids";

DROP SEQUENCE IF EXISTS "obj_which_can_be_commented_types_ids";

DROP SEQUENCE IF EXISTS "obj_which_can_be_named_types_ids";

DROP SEQUENCE IF EXISTS "territory_types_ids";

DROP SEQUENCE IF EXISTS "executor_types_ids";

DROP SEQUENCE IF EXISTS "legal_subject_types_ids";

DROP SEQUENCE IF EXISTS "obj_which_can_be_owned_types_ids";

CREATE SEQUENCE "notation_ids" increment by 512 start with 1;

CREATE SEQUENCE "language_ids" increment by 512 start with 2;

CREATE SEQUENCE "word_in_language_and_notation_ids" increment by 512 start with 3;

CREATE SEQUENCE "translation_unit_ids" increment by 512 start with 4;

CREATE SEQUENCE "translation_set_ids" increment by 512 start with 5;

CREATE SEQUENCE "obj_which_can_be_named_ids" increment by 512 start with 6;

CREATE SEQUENCE "text_for_markup_ids" increment by 512 start with 7;

CREATE SEQUENCE "markup_item_ids" increment by 512 start with 8;

CREATE SEQUENCE "notes_ids" increment by 512 start with 9;

CREATE SEQUENCE "notes_predcessors_array_ids" increment by 512 start with 10;

CREATE SEQUENCE "obj_which_can_be_commented_ids" increment by 512 start with 11;

CREATE SEQUENCE "dimension_formula_ids" increment by 512 start with 12;

CREATE SEQUENCE "dimension_formula_item_ids" increment by 512 start with 13;

CREATE SEQUENCE "location_vertex_ids" increment by 512 start with 14;

CREATE SEQUENCE "separation_line_ids" increment by 512 start with 15;

CREATE SEQUENCE "territory_ids" increment by 512 start with 16;

CREATE SEQUENCE "municipal_district_ids" increment by 512 start with 17;

CREATE SEQUENCE "federal_district_ids" increment by 512 start with 18;

CREATE SEQUENCE "country_ids" increment by 512 start with 19;

CREATE SEQUENCE "obj_which_can_be_owned_ids" increment by 512 start with 20;

CREATE SEQUENCE "executor_ids" increment by 512 start with 21;

CREATE SEQUENCE "legal_subject_ids" increment by 512 start with 22;

CREATE SEQUENCE "human_ids" increment by 512 start with 23;

CREATE SEQUENCE "ai_ids" increment by 512 start with 24;

CREATE SEQUENCE "government_ids" increment by 512 start with 25;

CREATE SEQUENCE "website_ids" increment by 512 start with 26;

CREATE SEQUENCE "company_ids" increment by 512 start with 27;

CREATE SEQUENCE "ownership_share_ids" increment by 512 start with 28;

CREATE SEQUENCE "legal_subject_contact_ids" increment by 512 start with 29;

CREATE SEQUENCE "communication_type_ids" increment by 512 start with 30;

CREATE SEQUENCE "office_ids" increment by 512 start with 31;

CREATE SEQUENCE "currency_ids" increment by 512 start with 32;

CREATE SEQUENCE "currency_value_ids" increment by 512 start with 33;

CREATE SEQUENCE "benefit_ids" increment by 512 start with 34;

CREATE SEQUENCE "requirement_ids" increment by 512 start with 35;

CREATE SEQUENCE "vacancy_ids" increment by 512 start with 36;

CREATE SEQUENCE "job_advertisement_distribution_channel_ids" increment by 512 start with 37;

CREATE SEQUENCE "advertisement_fact_ids" increment by 512 start with 38;

CREATE SEQUENCE "permission_ids" increment by 512 start with 39;

CREATE SEQUENCE "dbobject_ids" increment by 512 start with 40;

CREATE SEQUENCE "dbclass_ids" increment by 512 start with 41;

CREATE SEQUENCE "right_ids" increment by 512 start with 42;

CREATE SEQUENCE "default_right_ids" increment by 512 start with 43;

CREATE SEQUENCE "obj_which_can_be_commented_types_ids" increment by 512 start with 44;

CREATE SEQUENCE "obj_which_can_be_named_types_ids" increment by 512 start with 45;

CREATE SEQUENCE "territory_types_ids" increment by 512 start with 46;

CREATE SEQUENCE "executor_types_ids" increment by 512 start with 47;

CREATE SEQUENCE "legal_subject_types_ids" increment by 512 start with 48;

CREATE SEQUENCE "obj_which_can_be_owned_types_ids" increment by 512 start with 49;

CREATE TABLE "notation" (
    "notation_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('notation_ids'),
    "language_set_fk" INTEGER,
    "word_in_language_and_notation_set_fk" INTEGER
);

CREATE TABLE "language" (
    "language_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('language_ids'),
    "notation_array_fk" INTEGER
);

CREATE TABLE "word_in_language_and_notation" (
    "word_in_language_and_notation_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('word_in_language_and_notation_ids'),
    "word" VARCHAR
);

CREATE TABLE "translation_unit" (
    "translation_unit_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('translation_unit_ids')
);

CREATE TABLE "translation_set" (
    "translation_set_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('translation_set_ids'),
    "translation_unit_set_fk" INTEGER
);

CREATE TABLE "obj_which_can_be_named_types" (
    "obj_which_can_be_named_types_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('obj_which_can_be_named_types_ids'),
    "child_table_name" VARCHAR
);

CREATE TABLE "obj_which_can_be_named" (
    "obj_which_can_be_named_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('obj_which_can_be_named_ids'),
    "obj_which_can_be_named_types_fk" INTEGER
);

CREATE TABLE "text_for_markup" (
    "text_for_markup_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('text_for_markup_ids'),
    "text" VARCHAR
);

CREATE TABLE "obj_which_can_be_commented_types" (
    "obj_which_can_be_commented_types_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('obj_which_can_be_commented_types_ids'),
    "child_table_name" VARCHAR
);

CREATE TABLE "obj_which_can_be_commented" (
    "obj_which_can_be_commented_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('obj_which_can_be_commented_ids'),
    "obj_which_can_be_commented_types_fk" INTEGER,
    "obj_which_can_be_named_fk" INTEGER
);

CREATE TABLE "markup_item" (
    "markup_item_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('markup_item_ids'),
    "segment_start" DECIMAL,
    "segment_length" DECIMAL,
    "obj_which_can_be_commented_fk" INTEGER
);

CREATE TABLE "notes" (
    "notes_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('notes_ids')
);

CREATE TABLE "notes_predcessors_array" (
    "notes_predcessors_array_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('notes_predcessors_array_ids'),
    "obj_which_can_be_commented_array_fk" INTEGER
);

CREATE TABLE "dimension_formula" (
    "dimension_formula_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('dimension_formula_ids'),
    "dimension_formula_item_set_fk" INTEGER
);

CREATE TABLE "dimension_formula_item" (
    "dimension_formula_item_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('dimension_formula_item_ids'),
    "power_upper" DECIMAL,
    "power_lower" DECIMAL
);

CREATE TABLE "location_vertex" (
    "location_vertex_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('location_vertex_ids'),
    "coordinates" VARCHAR
);

CREATE TABLE "separation_line" (
    "separation_line_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('separation_line_ids')
);

CREATE TABLE "territory_types" (
    "territory_types_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('territory_types_ids'),
    "child_table_name" VARCHAR
);

CREATE TABLE "territory" (
    "territory_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('territory_ids'),
    "obj_which_can_be_named_fk" INTEGER,
    "territory_types_fk" INTEGER,
    "separation_line_set_fk" INTEGER
);

CREATE TABLE "municipal_district" (
    "municipal_district_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('municipal_district_ids'),
    "territory_fk" INTEGER
);

CREATE TABLE "federal_district" (
    "federal_district_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('federal_district_ids'),
    "territory_fk" INTEGER,
    "municipal_district_array_fk" INTEGER
);

CREATE TABLE "country" (
    "country_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('country_ids'),
    "territory_fk" INTEGER,
    "federal_district_array_fk" INTEGER,
    "language_array_fk" INTEGER
);

CREATE TABLE "obj_which_can_be_owned_types" (
    "obj_which_can_be_owned_types_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('obj_which_can_be_owned_types_ids'),
    "child_table_name" VARCHAR
);

CREATE TABLE "obj_which_can_be_owned" (
    "obj_which_can_be_owned_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('obj_which_can_be_owned_ids'),
    "description" VARCHAR,
    "obj_which_can_be_commented_fk" INTEGER,
    "obj_which_can_be_owned_types_fk" INTEGER,
    "legal_subject_set_fk" INTEGER
);

CREATE TABLE "executor_types" (
    "executor_types_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('executor_types_ids'),
    "child_table_name" VARCHAR
);

CREATE TABLE "executor" (
    "executor_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('executor_ids'),
    "obj_which_can_be_commented_fk" INTEGER,
    "executor_types_fk" INTEGER
);

CREATE TABLE "legal_subject_types" (
    "legal_subject_types_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('legal_subject_types_ids'),
    "child_table_name" VARCHAR
);

CREATE TABLE "legal_subject" (
    "legal_subject_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('legal_subject_ids'),
    "obj_which_can_be_commented_fk" INTEGER,
    "obj_which_can_be_named_fk" INTEGER,
    "legal_subject_types_fk" INTEGER,
    "right_set_fk" INTEGER,
    "obj_which_can_be_owned_set_fk" INTEGER
);

CREATE TABLE "human" (
    "human_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('human_ids'),
    "executor_fk" INTEGER,
    "legal_subject_fk" INTEGER
);

CREATE TABLE "ai" (
    "ai_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('ai_ids'),
    "obj_which_can_be_commented_fk" INTEGER,
    "executor_fk" INTEGER
);

CREATE TABLE "government" (
    "government_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('government_ids'),
    "country_code" VARCHAR,
    "obj_which_can_be_named_fk" INTEGER,
    "executor_set_fk" INTEGER
);

CREATE TABLE "website" (
    "website_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('website_ids'),
    "url" VARCHAR,
    "description" VARCHAR,
    "obj_which_can_be_owned_fk" INTEGER
);

CREATE TABLE "company" (
    "company_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('company_ids'),
    "agreement" VARCHAR,
    "mission" VARCHAR,
    "government_code" VARCHAR,
    "description" VARCHAR,
    "obj_which_can_be_owned_fk" INTEGER,
    "legal_subject_fk" INTEGER,
    "ownership_share_set_fk" INTEGER,
    "vacancy_set_fk" INTEGER,
    "office_set_fk" INTEGER,
    "website_array_fk" INTEGER
);

CREATE TABLE "ownership_share" (
    "ownership_share_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('ownership_share_ids'),
    "percentage_upper" DECIMAL,
    "percentage_lower" DECIMAL
);

CREATE TABLE "legal_subject_contact" (
    "legal_subject_contact_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('legal_subject_contact_ids'),
    "contact_info" VARCHAR,
    "obj_which_can_be_commented_fk" INTEGER
);

CREATE TABLE "communication_type" (
    "communication_type_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('communication_type_ids'),
    "obj_which_can_be_commented_fk" INTEGER,
    "obj_which_can_be_named_fk" INTEGER
);

CREATE TABLE "office" (
    "office_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('office_ids'),
    "office_name" VARCHAR,
    "office_address" VARCHAR,
    "description" VARCHAR,
    "obj_which_can_be_owned_fk" INTEGER,
    "legal_subject_contact_array_fk" INTEGER
);

CREATE TABLE "currency" (
    "currency_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('currency_ids'),
    "obj_which_can_be_named_fk" INTEGER
);

CREATE TABLE "currency_value" (
    "currency_value_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('currency_value_ids'),
    "date" DATE,
    "rate_upper" DECIMAL,
    "rate_lower" DECIMAL,
    "source_value_of_rate" VARCHAR
);

CREATE TABLE "benefit" (
    "benefit_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('benefit_ids'),
    "obj_which_can_be_commented_fk" INTEGER
);

CREATE TABLE "requirement" (
    "requirement_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('requirement_ids'),
    "req_name" VARCHAR,
    "obj_which_can_be_commented_fk" INTEGER
);

CREATE TABLE "vacancy" (
    "vacancy_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('vacancy_ids'),
    "compensation_upper" DECIMAL,
    "compensation_lower" DECIMAL,
    "official_url" VARCHAR,
    "obj_which_can_be_commented_fk" INTEGER,
    "requirement_array_fk" INTEGER,
    "benefit_array_fk" INTEGER
);

CREATE TABLE "job_advertisement_distribution_channel" (
    "job_advertisement_distribution_channel_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('job_advertisement_distribution_channel_ids'),
    "description" VARCHAR,
    "obj_which_can_be_owned_fk" INTEGER,
    "advertisement_fact_set_fk" INTEGER
);

CREATE TABLE "advertisement_fact" (
    "advertisement_fact_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('advertisement_fact_ids'),
    "unofficial_url" VARCHAR,
    "obj_which_can_be_commented_fk" INTEGER
);

CREATE TABLE "permission" (
    "permission_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('permission_ids')
);

CREATE TABLE "dbobject" (
    "dbobject_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('dbobject_ids')
);

CREATE TABLE "dbclass" (
    "dbclass_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('dbclass_ids'),
    "name_of_class" VARCHAR
);

CREATE TABLE "right" (
    "right_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('right_ids'),
    "dbobject_set_fk" INTEGER,
    "permission_set_fk" INTEGER
);

CREATE TABLE "default_right" (
    "default_right_pk" INTEGER PRIMARY KEY DEFAULT NEXTVAL('default_right_ids')
);

CREATE TABLE "set_notation_language" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_notation_word_in_language_and_notation" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_translation_set_translation_unit" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_dimension_formula_dimension_formula_item" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_territory_separation_line" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_obj_which_can_be_owned_legal_subject" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_legal_subject_right" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_legal_subject_obj_which_can_be_owned" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_government_executor" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_company_ownership_share" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_company_vacancy" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_company_office" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_job_advertisement_distribution_channel_advertisement_fact" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_right_dbobject" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "set_right_permission" (
    "set_id" INTEGER,
    "item_fk" INTEGER
);

CREATE TABLE "array_language_notation" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_notes_predcessors_array_obj_which_can_be_commented" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_federal_district_municipal_district" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_country_federal_district" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_country_language" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_company_website" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_office_legal_subject_contact" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_vacancy_requirement" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);

CREATE TABLE "array_vacancy_benefit" (
    "array_id" INTEGER,
    "item_num" DECIMAL,
    "item_fk" INTEGER
);
