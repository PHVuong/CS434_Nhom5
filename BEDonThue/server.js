import express from "express";
import cors from "cors";
import { initDB } from "./models/order.model.js";
import orderRoutes from "./routes/order.routes.js";

const app = express();
const PORT = 3000;

// Middleware
app.use(cors());
app.use(express.json());

// Init DB
initDB();

// Routes
app.use("/api/orders", orderRoutes);

// Start server
app.listen(PORT, () => {
  console.log(`Backend đang chạy tại http://localhost:${PORT}`);
});
