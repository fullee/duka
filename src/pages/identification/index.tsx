import {useEffect, useState} from 'react'
import {invoke} from "@tauri-apps/api";
import {Button} from "antd";
import {Link} from "react-router-dom";

function Identification() {
  const [count, setCount] = useState(0)
  const [title, setTitle] = useState<string>('')
  useEffect(() => {
    invoke('greet', {name: "xff"})
      .then((resp) => setTitle(String(resp)))
  }, [])

  return (
    <div>
      <Link to="/" >BACK</Link>
      <h1 className="text-white">请将身份证放置打印机识别区域</h1>
      <div className="card">
        <Button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </Button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
        <Button onClick={async () => {
          const resp: string = await invoke('cvr', {})

          if (resp) {
            setTitle(resp);
            alert("读卡完成")
          } else {
            setTitle('');
            alert("请重新放置身份证")
          }
        }}>打开
        </Button>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </div>
  )
}

export default Identification
