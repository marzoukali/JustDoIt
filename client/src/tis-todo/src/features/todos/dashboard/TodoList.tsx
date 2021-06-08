import { observer } from 'mobx-react-lite';
import { SyntheticEvent, useState } from 'react';
import {Button, Item, Label, Segment} from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';



export default observer(function TodoList(){
    const {todoStore, userStore} = useStore();
    const [target, setTarget] = useState('');

    function handleTodoItemDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        todoStore.deleteTodoItem(userStore.user?.userId!, id);
    }
    
    return (
        <Segment>
            <Item.Group divided>
                {todoStore.todoItemsByCreatedDate.map(item => (
                    <Item key={item.id}>
                        <Item.Content>
                            <Item.Header as='a'>{item.title}</Item.Header>
                            <Item.Meta>Created At: {item.createdAt}</Item.Meta>
                            <Item.Meta>Last Updated At: {item.lastUpdatedAt}</Item.Meta>
                            <Item.Description>
                                <div>Due At: {item.dueAt}</div>
                                <div>{item.isComplete}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button onClick={() => todoStore.selectTodoItem(item.id)} floated='right' content='View' color='blue' />
                                <Button
                                name={item.id}
                                 loading={todoStore.loading && target === item.id}
                                  onClick={(e) => handleTodoItemDelete(e, item.id)}
                                   floated='right'
                                    content='Delete'
                                     color='red' />
                                <Label basic content={item.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})