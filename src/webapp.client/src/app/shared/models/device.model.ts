import { Sensor } from "./sensor.model";

export interface Device {
    id: number;
    name: string;
    status?: string;
    sensors?: Sensor[];
}
