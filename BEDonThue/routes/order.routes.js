import express from "express";
import { OrderController } from "../controllers/order.controller.js";

const router = express.Router();

router.get("/", OrderController.getAll);
router.get("/:id", OrderController.getOne);
router.post("/", OrderController.create);
router.patch("/:id", OrderController.updateStatus);

export default router;
