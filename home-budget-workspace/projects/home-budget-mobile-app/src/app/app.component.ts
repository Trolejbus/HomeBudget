import { ChangeDetectionStrategy, Component } from '@angular/core';
import { SwPush } from '@angular/service-worker';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  readonly VAPID_PUBLIC_KEY = "BE-jdntMfI0JHJ-1hAZg4VnUCyiCJDOTB4qKOgErUoVG6l2kzTkR4ewKH6yLZg9g24LFeXQg8eSIHz8NhoTYY50";

  public error = '';
  public test = '1';

  constructor(
    private swPush: SwPush,
  ) {

    this.swPush.messages.subscribe(m => console.log(m));
  }

  public sub(): void {
    this.swPush.requestSubscription({
      serverPublicKey: this.VAPID_PUBLIC_KEY
    })
    .then(sub => { console.log('test', sub.toJSON(), this.arrayBufferToBase64(sub.getKey("p256dh")), this.arrayBufferToBase64(sub.getKey("auth"))); this.test = '2'; })
    .catch((err: Error) => { console.error("Could not subscribe to notifications", err); this.error = err.message; });
  
  }

  private arrayBufferToBase64(buffer: ArrayBuffer | null): string {
    if (buffer == null) {
      throw new Error('Cannot be null');
    }

    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
  };
}
