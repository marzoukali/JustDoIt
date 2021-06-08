import {makeAutoObservable, runInAction} from 'mobx';
import agent from '../api/agent';
import { TodoItem } from '../models/todo-item';
import {v4 as uuid} from 'uuid';
import { useStore } from './store';


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

    loadTodoItems = async (userId: string) => {
        try{
            const incomingTodoItems = await agent.TodoItems.list(userId);
                incomingTodoItems.forEach(item => {
                    item.createdAt = item.createdAt.split('T')[0];
                    item.dueAt = item.dueAt.split('T')[0];
                    item.lastUpdatedAt = item.lastUpdatedAt.split('T')[0];
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

    createTodoItem = async(userId: string, todoItem: TodoItem) => {
        this.loading = true;
        todoItem.id = uuid();
        todoItem.createdAt = new Date().toISOString()
        todoItem.lastUpdatedAt = new Date().toISOString()
        try{
            await agent.TodoItems.create(userId, todoItem);
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

    updateTodoItem = async (userId: string,todoItem: TodoItem) => {
        this.loading = true;
        try{
            await agent.TodoItems.update(userId, todoItem);
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


    deleteTodoItem = async (userId: string, id: string) => {
        this.loading = true;
        try{
            await agent.TodoItems.delete(userId, id);
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


