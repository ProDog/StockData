/*
 Navicat Premium Data Transfer

 Source Server         : GripStock
 Source Server Type    : SQLite
 Source Server Version : 3017000
 Source Schema         : main

 Target Server Type    : SQLite
 Target Server Version : 3017000
 File Encoding         : 65001

 Date: 03/04/2018 17:11:50
*/

PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for StockHisTradeData
-- ----------------------------
DROP TABLE IF EXISTS "StockHisTradeData";
CREATE TABLE "StockHisTradeData" (
  "ID" text NOT NULL,
  "Code" TEXT NOT NULL,
  "StartDate" TEXT,
  "StartPrice" real,
  "EndPrice" REAL,
  "ChangePrice" REAL,
  "ChangeRatio" TEXT,
  "LowPrice" REAL,
  "HighPrice" REAL,
  "TotalHand" TEXT,
  "TotalAmount" TEXT,
  "ChangeHandRate" TEXT,
  "UpdateDate" TEXT,
  PRIMARY KEY ("ID")
);

PRAGMA foreign_keys = true;
