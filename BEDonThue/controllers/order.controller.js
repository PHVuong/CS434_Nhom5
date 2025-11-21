import db from "../models/order.model.js";
import { nanoid } from "nanoid";

export const OrderController = {
  getAll: async (req, res) => {
    await db.read();
    res.json(db.data.orders);
  },

  getOne: async (req, res) => {
    await db.read();

    const order = db.data.orders.find(o => o.id === req.params.id);
    if (!order) return res.status(404).json({ message: "Not found" });

    res.json(order);
  },

  create: async (req, res) => {
    await db.read();

    const newOrder = {
      id: "DH" + nanoid(6).toUpperCase(),
      ...req.body,
      status: "pending"
    };

    db.data.orders.push(newOrder);
    await db.write();

    res.status(201).json(newOrder);
  },

  updateStatus: async (req, res) => {
    await db.read();

    const order = db.data.orders.find(o => o.id === req.params.id);
    if (!order) return res.status(404).json({ message: "Not found" });

    order.status = req.body.status;
    await db.write();

    res.json(order);
  }
};
