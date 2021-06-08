import {Button, Card} from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';




export default function TodoDetails(){

    const {todoStore} = useStore();

    return (
        <Card fluid>
            <Card.Content>
                <Card.Header style={{marginBottom:'10px'}}>{todoStore.selectedTodoItem!.title}</Card.Header>
                <Card.Meta className='meta'>
                    <div className='date' style={{color:'#333', marginLeft:'10px'}}>Created At: {todoStore.selectedTodoItem!.createdAt}</div>
                    <div className='date' style={{color:'#333', marginLeft:'10px'}}>Last Updated At: {todoStore.selectedTodoItem!.lastUpdatedAt}</div>
                    <div className='date' style={{color:'red', marginLeft:'10px'}}>Due Date: {todoStore.selectedTodoItem!.dueAt}</div>
                </Card.Meta>
                <Card.Description height='5' className='description' style={{color:'#000', marginLeft:'10px'}}>{todoStore.selectedTodoItem!.description}</Card.Description>
            </Card.Content>
            <Card.Content extra>
               <Button.Group widths='2'>
                   <Button onClick={() => todoStore.openForm(todoStore.selectedTodoItem!.id)} basic color='blue' content='Edit' />
                   <Button onClick={todoStore.cancelSelectedTodoItem} basic color='grey' content='Cancel' />
               </Button.Group>
            </Card.Content>
        </Card>
    )
}