import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import {TodoItem} from '../models/todo-item'
import Navbar from '../layout/Navbar'


function App() {
  const [todoCategories, setTodoItems] = useState<TodoItem[]>([]);

  useEffect(() => {
    axios.get<TodoItem[]>('https://localhost:5301/api/UserTodos').then(res => {
      setTodoItems(res.data);
    })
  }, [])

  return (
    <Fragment>
      <Navbar />
      <Container style={{marginTop: '7em'}}>
      <List>
          {todoCategories.map(todoItem  => (
            <List.Item key={todoItem.id}>{todoItem.title}</List.Item>
          ))}
        </List>
      </Container>
    </Fragment>
  );
}

export default App;
