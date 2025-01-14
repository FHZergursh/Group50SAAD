import axios from 'axios';
import {useState, useEffect} from 'react';
export default function TableList({ onOpen}) {

    const [media, setMedia] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fethData = async () => {
            try{
                const response=await axios.get("http://localhost:8800/media")
                setMedia(response.data)

            } catch (err){
                setError(err.message);
            }
        }
    })





    const tableData = [
        { idmedia: 1, name: "Harry Potter", type:"Book", description: "A book by JK Rowling", Stock: 100},
        { idmedia: 2, name: "Star Wars", type:"Disc", description: "An example disc", Stock: 200},
        { idmedia: 3, name: "BookExample3", type:"Book", description: "An example book", Stock: 0 },
    ];

    return (
        <>
        <div className="overflow-x-auto mt-10">
            <table className="table">
                <thead>
                <tr>
                    <th>idmedia</th>
                    <th>Name</th>
                    <th>type</th>
                    <th>description</th>
                    <th>Stock</th>
                    <th>Borrow</th>
                    <th></th>
                    <th></th>

                
                </tr>
                </thead>
                {/* ++ hover */}
                <tbody className="hover">
                {/* row 1 */}
                    {tableData.map((item) => (
                        <tr key={item.idmedia} className="hover">
                            <th>{item.idmedia}</th>
                            <td>{item.name}</td>
                            <td>{item.type}</td>
                            <td>{item.description}</td>
                            <td>{item.Stock}</td>
                            {/* ++button logic ++rounded-full w-20  */}
                            <td>
                                <button className="btn btn-accent">Borrow media</button>
                            </td>
                        </tr>
                    ))}
        
                </tbody>
            </table>
            </div>
        </>
    )
}