import { Formik, Form, Field, ErrorMessage } from 'formik';
import { values } from 'mobx';
import { observer } from 'mobx-react-lite';
import  {  ChangeEvent, useState } from 'react';
import {Button, Header, Segment} from 'semantic-ui-react';
import * as Yup from 'yup';
import TextInput from '../../../app/common/form/TextInput';
import TextArea from '../../../app/common/form/TextArea';
import { categoryOptions } from '../../../app/common/options/categoryOptions';
import { useStore } from '../../../app/stores/store';


export default observer(function TodoForm(){

    const {todoStore, userStore} = useStore();

    const initialState = todoStore.selectedTodoItem ?? {
        id: '',
        title: '',
        description: '',
        createdAt:  '',
        lastUpdatedAt: '',
        dueAt: '',
        isComplete: false,
        creatorId: '',
        category: ''
    }

    const validationSchema = Yup.object({
        title: Yup.string().required('Todo title is required!'),
    })
    

    const [todoItem, setTodoItem] = useState(initialState);
    


    function handleFormSubmit(){
        const userId = userStore.user?.userId!;
       todoItem.id ? todoStore.updateTodoItem(userId, todoItem) : todoStore.createTodoItem(userId, todoItem);
    }


    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>)
    {
        const {name, value} = event.target;
        setTodoItem({...todoItem, [name]: value})
    }

    
    function handleSelectChange(event: ChangeEvent<HTMLSelectElement>)
    {
        event.preventDefault();
        todoItem.category = event.target.value;
        setTodoItem(todoItem)
    }


    function handleCheckChange(event: ChangeEvent<HTMLInputElement>){
        todoItem.isComplete = event.target.checked;
        setTodoItem(todoItem)
    }
    

    return (
        <Segment clearing>
            <Header content='Todo Details' sub color='teal' />

            <Formik
            validationSchema={validationSchema}
            enableReinitialize
             initialValues={todoItem}
              onSubmit={values => handleFormSubmit()}>
                {({handleSubmit, isValid, isSubmitting, dirty }) => (
            <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                <TextInput placeholder='Title' name='title' onChange={handleInputChange}  />
                <TextArea rows={3} placeholder='Description'  name='description' onChange={handleInputChange}  />
                <select  name='category' onChange={handleSelectChange} value={todoItem.category}>
                <option  value={categoryOptions[0].text}>{categoryOptions[0].text}</option>
                <option  value={categoryOptions[1].text}>{categoryOptions[1].text}</option>
                <option  value={categoryOptions[2].text}>{categoryOptions[2].text}</option>
                <option  value={categoryOptions[3].text}>{categoryOptions[3].text}</option>
                <option  value={categoryOptions[4].text}>{categoryOptions[4].text}</option>
                <option  value={categoryOptions[5].text}>{categoryOptions[5].text}</option>
                </select>
                <br />
                <input type='checkbox'
                  style={{margin:'5px'}}
                    placeholder='Completed'
                       name='completed'
                        onChange={handleCheckChange}
                         defaultChecked={todoItem.isComplete}/>
                <label htmlFor='completed' title='Completed'>Completed</label>
                         <br />
                <label htmlFor='dueAt' title='dueAt'>Due At</label>
                <br />
                <input type='date' placeholder='Due Date'  value={todoItem.dueAt} name='dueAt' onChange={handleInputChange}  />                
                <Button disabled={isSubmitting ||  !isValid} loading={todoStore.loading} floated='right' positive type='submit' content='submit' />
                <Button onClick={todoStore.closeForm} floated='right'  type='button' content='cancel' />
           </Form>
                )}
            </Formik>

        </Segment>
    )
})