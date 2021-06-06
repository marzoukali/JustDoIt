import {makeAutoObservable, runInAction} from 'mobx';
import agent from '../api/agent';
import { TodoItem } from '../models/todo-item';
import {v4 as uuid} from 'uuid';


export default class TodoStore{
    todosRegistery = new Map<string, TodoItem>();
    selectedTodoItem: TodoItem | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;


    constructor(){
        makeAutoObservable(this)
    }

    get todoItemsByCreatedDate(){
        return Array.from(this.todosRegistery.values()).sort((a, b) => Date.parse(a.createdAt) - Date.parse(b.createdAt));
    }

    loadTodoItems = async () => {
        try{
            const incomingTodoItems = await agent.TodoItems.list();
                incomingTodoItems.forEach(item => {
                    item.createdAt = item.createdAt.split('T')[0];
                    item.dueAt = item.dueAt.split('T')[0];
                    this.todosRegistery.set(item.id, item);
                })
                this.setLoadingInitial(false);
            }catch(error){
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    selectTodoItem = (id: string) => {
        this.selectedTodoItem = this.todosRegistery.get(id);
    }

    cancelSelectedTodoItem = () => {
        this.selectedTodoItem = undefined;
    }

    openForm = (id?: string) => {
        id ? this.selectTodoItem(id) : this.cancelSelectedTodoItem();
        this.editMode = true;
    }

    closeForm = () => {
        this.editMode = false;
    }

    createTodoItem = async(todoItem: TodoItem) => {
        this.loading = true;
        todoItem.id = uuid();
        try{
            await agent.TodoItems.create(todoItem);
            runInAction(() => {
                this.todosRegistery.set(todoItem.id, todoItem);
                this.selectedTodoItem = todoItem;
                this.editMode = false;
                this.loading = false;
            })
        }catch(error){
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    updateTodoItem = async (todoItem: TodoItem) => {
        this.loading = true;
        try{
            console.log('test1');
            console.log(todoItem);
            await agent.TodoItems.update(todoItem);
            runInAction(() => {
                this.todosRegistery.set(todoItem.id, todoItem);
                this.selectedTodoItem = todoItem;
                this.editMode = false;
                this.loading = false;
            })
        }catch(error){
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }


    deleteTodoItem = async (id: string) => {
        this.loading = true;
        try{
            await agent.TodoItems.delete(id);
            runInAction(() => {
                this.todosRegistery.delete(id);
                if(this.selectedTodoItem?.id === id)
                {
                    this.cancelSelectedTodoItem();
                }

                this.loading = false;
            })
        }catch(error){
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
}


