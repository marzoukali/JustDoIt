import { observer } from 'mobx-react-lite';
import  { ChangeEvent, useState } from 'react';
import {Button, Form, Segment} from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';


export default observer(function TodoForm(){

    const {todoStore} = useStore();

    const initialState = todoStore.selectedTodoItem ?? {
        id: '',
        title: '',
        createdAt: '',
        dueAt: '',
        isComplete: false,
        creatorId: '',
        categoryId: 0,
        categoryName: ''
    }

    const [todoItem, setTodoItem] = useState(initialState);
    
    function handleSubmit(){
       todoItem.id ? todoStore.updateTodoItem(todoItem) : todoStore.createTodoItem(todoItem);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>)
    {
        const {name, value} = event.target;
        setTodoItem({...todoItem, [name]: value})
    }


    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete='off'>
                <Form.Input placeholder='Title' value={todoItem.title} name='title' onChange={handleInputChange} />
                <Form.TextArea placeholder='Description' value={todoItem.title} name='description' onChange={handleInputChange} />
                <Form.Checkbox label='Completed' checked={todoItem.isComplete}  name='completed'/>
                <Form.Input type='date' placeholder='Due Date'  value={todoItem.dueAt} name='due date' onChange={handleInputChange} />
                <Button loading={todoStore.loading} floated='right' positive type='submit' content='submit' />


                <Button onClick={todoStore.closeForm} floated='right'  type='button' content='cancel' />
            </Form>
        </Segment>
    )
})