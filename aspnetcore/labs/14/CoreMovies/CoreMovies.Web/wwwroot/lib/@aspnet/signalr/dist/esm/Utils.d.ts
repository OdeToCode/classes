import { HttpClient } from "./HttpClient";
import { ILogger, LogLevel } from "./ILogger";
import { IStreamResult, IStreamSubscriber, ISubscription } from "./Stream";
/** @private */
export declare class Arg {
    static isRequired(val: any, name: string): void;
    static isIn(val: any, values: any, name: string): void;
}
/** @private */
export declare function getDataDetail(data: any, includeContent: boolean): string;
/** @private */
export declare function formatArrayBuffer(data: ArrayBuffer): string;
/** @private */
export declare function isArrayBuffer(val: any): val is ArrayBuffer;
/** @private */
export declare function sendMessage(logger: ILogger, transportName: string, httpClient: HttpClient, url: string, accessTokenFactory: (() => string | Promise<string>) | undefined, content: string | ArrayBuffer, logMessageContent: boolean): Promise<void>;
/** @private */
export declare function createLogger(logger?: ILogger | LogLevel): ILogger;
/** @private */
export declare class Subject<T> implements IStreamResult<T> {
    observers: Array<IStreamSubscriber<T>>;
    cancelCallback?: () => Promise<void>;
    constructor();
    next(item: T): void;
    error(err: any): void;
    complete(): void;
    subscribe(observer: IStreamSubscriber<T>): ISubscription<T>;
}
/** @private */
export declare class SubjectSubscription<T> implements ISubscription<T> {
    private subject;
    private observer;
    constructor(subject: Subject<T>, observer: IStreamSubscriber<T>);
    dispose(): void;
}
/** @private */
export declare class ConsoleLogger implements ILogger {
    private readonly minimumLogLevel;
    constructor(minimumLogLevel: LogLevel);
    log(logLevel: LogLevel, message: string): void;
}
