import { Low } from 'lowdb'
import { JSONFile } from 'lowdb/node'
import { join } from 'path'

// Đường dẫn tới file db.json
const file = join(process.cwd(), 'BE', 'db.json')

// LowDB yêu cầu truyền default data ngay khi tạo DB
const adapter = new JSONFile(file)
const db = new Low(adapter, { orders: [] })

export async function initDB() {
  await db.read()

  // Nếu db.json rỗng, lowdb sẽ dùng default data { orders: [] }
  await db.write()
}

export default db
