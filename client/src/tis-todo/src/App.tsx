import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [todoCategories, setTodoCategories] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5301/WeatherForecast').then(res => {
      setTodoCategories(res.data);
    })
  }, [])

  return (
    <div>
      <Header as="h2" icon="list" content="JustDoIt" />
        <List>
          {todoCategories.map((category: any) => (
            <List.Item key={category.id}>{category.title}</List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
