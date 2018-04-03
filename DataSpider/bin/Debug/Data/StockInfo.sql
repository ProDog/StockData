/*
 Navicat Premium Data Transfer

 Source Server         : GripStock
 Source Server Type    : SQLite
 Source Server Version : 3017000
 Source Schema         : main

 Target Server Type    : SQLite
 Target Server Version : 3017000
 File Encoding         : 65001

 Date: 02/04/2018 17:16:34
*/

PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for StockInfo
-- ----------------------------
DROP TABLE IF EXISTS "StockInfo";
CREATE TABLE "StockInfo" (
  "Stock_Code" text NOT NULL,
  "Stock_Name" TEXT,
  "Stock_Type" integer NOT NULL,
  "Stock_Exchange" TEXT,
  "Stock_StartDate" text,
  "Stock_CreateDate" TEXT,
  PRIMARY KEY ("Stock_Code")
);

PRAGMA foreign_keys = true;
