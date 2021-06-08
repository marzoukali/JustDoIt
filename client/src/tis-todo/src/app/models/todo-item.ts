import { TodoCategory } from "./todo-category";

export interface TodoItem {
    id: string;
    title: string;
    description: string;
    createdAt: string;
    lastUpdatedAt: string;
    dueAt: string;
    isComplete: boolean;
    creatorId: string;
    category: string;
}