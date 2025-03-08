import { Sensor } from "./sensor.model";

export interface Device {
    id: number;
    name: string;
    sensors: Sensor[];
}
