import {createContext, useContext} from 'react';
import TodoStore from "./todoStore";
import CommonStore from "./commonStore";



interface Store {
    todoStore: TodoStore;
    commonStore: CommonStore;
}

export const store: Store = {
    todoStore: new TodoStore(),
    commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}