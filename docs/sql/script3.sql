-- формула размерности

CREATE TABLE dimension_definition_state
(
	dimension_definition_id integer,
	dimension_definition_change_id,
	change_comment varchar
)

CREATE TABLE dimension_definition_part_state
(
	dimension_definition_id integer, -- parent array object
	position integer, -- позиция в формуле
	unit_fk REFERENCE -- название единицы изменения
	power_of_dimension FLOAT, -- в какую степень возводить
	dimension_definition_part_state_id INTEGER -- just id
)

CREATE TABLE dimension_definition_event
(
	dimension_definition_event_id integer, -- идентификатор конкретной операции (не используется?)
	change_date datetime, -- by dataserver clocks
	change_comment varchar,
	dimension_definition_id integer, -- что стало после изменения
	change_type_fk NREFERENCE -- тип изменения (create, delete, change)
)

-- целые величины (например рубли)

CREATE TABLE integer_quantities_state
(
	quantity_id integer, -- прослеживает идентичность этой ветки изменений (неуникальное)
	integer_quantities_change_id -- изменение, которым установлено текущее значение
	quantity_value integer,
	dimension_definition_fk REFERENCE, -- формула размерности величины
)

CREATE TABLE integer_quantities_event
(
	quantity_event_id integer, -- идентификатор конкретной операции (не используется?)
	integer_quantities_event_id integer,
	change_date datetime, -- by dataserver clocks
	change_type_fk NREFERENCE,
	change_comment varchar
)

CREATE TABLE integer_quantities_value_change_event
(
	quantity_event_id integer, -- идентификатор конкретной операции (не используется?)
	integer_quantities_event_fk NINHERITANCE,
	quantity_after_id, // previous state
	quantity_before_id // next state
	-- comment is inherited
}

-- нужна ещё таблицы-справочники:
--  видов величин (например рубли)
--  видов операций по разновидностям объектов (создание, удаление, изменение значения ячейки в столбце [связанной] записи)
