-- Script Date: 11/15/2020 1:52 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
CREATE TABLE [ToDoList] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [userId] bigint NOT NULL
, [state] text NOT NULL
, [label] text NOT NULL
, [tags] text NULL
, [hex] text NULL
, [resourceId] bigint NULL
);
